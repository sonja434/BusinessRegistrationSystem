using AutoMapper;
using firm_registry_api.DTOs;
using firm_registry_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace firm_registry_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyRequestsController : ControllerBase
    {
        private readonly ICompanyRequestService _service;
        private readonly IMapper _mapper;

        public CompanyRequestsController(ICompanyRequestService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateRequest(
    [FromForm] string request,
    IFormFileCollection DocumentFiles)
        {
            // Opcije za deserializaciju (CamelCase i CaseInsensitive)
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };

            CompanyRequestDto dto;

            try
            {
                using var document = JsonDocument.Parse(request);
                var root = document.RootElement;

                if (!root.TryGetProperty("Type", out var typeElement) || typeElement.ValueKind != JsonValueKind.Number)
                {
                    return BadRequest("JSON zahtev ne sadrži validan numerički diskriminator 'Type'.");
                }

                var typeId = typeElement.GetInt32();

                switch (typeId)
                {
                    case 0: 
                        dto = JsonSerializer.Deserialize<EntrepreneurRequestDto>(request, options);
                        break;
                    case 1: 
                        dto = JsonSerializer.Deserialize<LimitedCompanyRequestDto>(request, options);
                        break;
                    case 2: 
                        dto = JsonSerializer.Deserialize<JointStockCompanyRequestDto>(request, options);
                        break;
                    case 3: 
                        dto = JsonSerializer.Deserialize<PartnershipRequestDto>(request, options);
                        break;
                    case 4: 
                        dto = JsonSerializer.Deserialize<LimitedPartnershipRequestDto>(request, options);
                        break;
                    default:
                        return BadRequest("Nepoznat tip firme (Type) u zahtevu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Greška pri parsiranju JSON zahteva: {ex.Message}");
            }

            if (dto == null)
            {
                return BadRequest("Podaci zahteva nisu validni.");
            }


            dto.DocumentFiles = DocumentFiles.ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var entity = await _service.CreateRequestAsync(dto, userId);

            return Ok(_mapper.Map<CompanyRequestResponseDto>(entity));
        }

        [HttpPut("user/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateRequestByUser(int id, [FromBody] UserUpdateCompanyRequestDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = await _service.UpdateRequestByUserAsync(id, dto, userId);
            return Ok(_mapper.Map<CompanyRequestResponseDto>(request));
        }

        [HttpPut("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRequestByAdmin(int id, [FromBody] AdminUpdateCompanyRequestDto dto)
        {
            var request = await _service.UpdateRequestByAdminAsync(id, dto);
            return Ok(_mapper.Map<CompanyRequestResponseDto>(request));
        }

        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserRequests([FromQuery] CompanyRequestQueryParams queryParams)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            queryParams.UserId = userId; 
            var pagedResult = await _service.GetRequestsByUserAsync(queryParams);

            return Ok(new
            {
                Items = _mapper.Map<List<CompanyRequestResponseDto>>(pagedResult.Items),
                pagedResult.TotalCount,
                pagedResult.Page,
                pagedResult.PageSize
            });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRequests([FromQuery] CompanyRequestQueryParams queryParams)
        {
            var pagedResult = await _service.GetAllRequestsAsync(queryParams);

            return Ok(new
            {
                Items = _mapper.Map<List<CompanyRequestResponseDto>>(pagedResult.Items),
                pagedResult.TotalCount,
                pagedResult.Page,
                pagedResult.PageSize
            });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRequest(int id)
        {
            var request = await _service.GetRequestByIdAsync(id);
            if (request == null)
                return NotFound();
            return Ok(_mapper.Map<CompanyRequestResponseDto>(request));
        }

        [HttpGet("user/{id}/pdf")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DownloadRequestPdf(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var pdfBytes = await _service.GenerateRequestPdfAsync(id, userId);

            if (pdfBytes == null || pdfBytes.Length == 0)
                return NotFound("PDF could not be generated.");

            return File(pdfBytes, "application/pdf", $"Request_{id}.pdf");
        }

        [HttpGet("{requestId}/documents/{fileName}")]
        [Authorize]
        public async Task<IActionResult> DownloadDocument(int requestId, string fileName)
        {
            var request = await _service.GetRequestByIdAsync(requestId);
            if (request == null)
                return NotFound("Request not found.");

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (userRole != "Admin" && request.UserId != userId)
                return Forbid();

            var filePath = Path.Combine("Uploads", fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            var contentType = "application/octet-stream";
            var ext = Path.GetExtension(fileName).ToLower();
            if (ext == ".pdf") contentType = "application/pdf";
            else if (ext == ".jpg" || ext == ".jpeg") contentType = "image/jpeg";
            else if (ext == ".png") contentType = "image/png";

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, contentType, fileName);
        }
    }
}
