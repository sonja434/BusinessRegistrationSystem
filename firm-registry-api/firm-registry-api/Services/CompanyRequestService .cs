using AutoMapper;
using firm_registry_api.DTOs;
using firm_registry_api.Models;
using firm_registry_api.Models.Enums;
using firm_registry_api.Repositories.Interfaces;
using firm_registry_api.Services.Interfaces;

namespace firm_registry_api.Services
{
    public class CompanyRequestService : ICompanyRequestService
    {
        private readonly ICompanyRequestRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IPdfService _pdfService;

        public CompanyRequestService(ICompanyRequestRepository repository, IMapper mapper, IEmailService emailService, IPdfService pdfService)
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
            _pdfService = pdfService;
        }

        public async Task<CompanyRequest> CreateRequestAsync(CompanyRequestDto dto, int userId)
        {
            var entity = _mapper.Map<CompanyRequest>(dto);
            entity.UserId = userId;
            entity.Status = RequestStatus.Pending;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            if (dto.DocumentFiles != null && dto.DocumentFiles.Any())
            {
                ValidateFiles(dto.DocumentFiles);
                foreach (var file in dto.DocumentFiles)
                {
                    var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                    var path = Path.Combine("Uploads", fileName);
                    Directory.CreateDirectory("Uploads"); 
                    using var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    entity.Documents.Add(fileName); 
                }
            }

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task<CompanyRequest> UpdateRequestByUserAsync(int requestId, UserUpdateCompanyRequestDto dto, int userId)
        {
            var request = await _repository.GetByIdAsync(requestId);
            if (request == null)
                throw new KeyNotFoundException("Request not found.");
            if (request.UserId != userId)
                throw new UnauthorizedAccessException("You can only update your own requests.");
            if (request.Status == RequestStatus.Approved || request.Status == RequestStatus.Rejected)
                throw new InvalidOperationException("Cannot update request already reviewed by admin.");

            if (dto.CancelRequest)
                request.Status = RequestStatus.Cancelled;

            if (dto.DocumentFiles != null && dto.DocumentFiles.Any())
            {
                ValidateFiles(dto.DocumentFiles);
                foreach (var file in dto.DocumentFiles)
                {
                    var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                    var path = Path.Combine("Uploads", fileName);
                    Directory.CreateDirectory("Uploads");
                    using var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    request.Documents.Add(fileName);
                }
            }

            request.UpdatedAt = DateTime.Now;
            await _repository.UpdateAsync(request);
            await _repository.SaveChangesAsync();
            return request;
        }

        public async Task<CompanyRequest> UpdateRequestByAdminAsync(int requestId, AdminUpdateCompanyRequestDto dto)
        {
            var request = await _repository.GetByIdAsync(requestId);

            if (request == null)
                throw new KeyNotFoundException("Request not found.");

            request.Status = dto.Status;
            request.AdminNotes = dto.AdminNotes;
            request.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(request);
            await _repository.SaveChangesAsync();

            var emailBody = $"Vaš zahtev za registraciju firme '{request.CompanyName}' je obrađen.\n" +
                            $"Status: {request.Status}\n" +
                            $"Napomena od admina: {request.AdminNotes}";

            await _emailService.SendEmailAsync(request.User.Email, "Vaš zahtev je obrađen", emailBody);

            return request;
        }

        public async Task<CompanyRequest> GetRequestByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<PagedResult<CompanyRequest>> GetRequestsByUserAsync(CompanyRequestQueryParams queryParams)
        {
            if (!queryParams.UserId.HasValue)
                throw new ArgumentException("UserId must be provided for user requests.");

            return await _repository.GetCompanyRequestsAsync(queryParams);
        }

        public async Task<PagedResult<CompanyRequest>> GetAllRequestsAsync(CompanyRequestQueryParams queryParams)
        {
            return await _repository.GetCompanyRequestsAsync(queryParams);
        }

        public async Task<byte[]> GenerateRequestPdfAsync(int requestId, int userId)
        {
            var request = await _repository.GetByIdAsync(requestId);

            if (request == null)
                throw new KeyNotFoundException("Request not found.");

            if (request.UserId != userId)
                throw new UnauthorizedAccessException("You can only generate PDF for your own requests.");

            return await _pdfService.GenerateCompanyRequestPdfAsync(request);
        }

        private void ValidateFiles(List<IFormFile> files)
        {
            var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png" };
            long maxFileSize = 5 * 1024 * 1024;

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                    throw new InvalidOperationException($"File type '{extension}' is not allowed.");

                if (file.Length > maxFileSize)
                    throw new InvalidOperationException($"File '{file.FileName}' exceeds maximum size of 5 MB.");
            }
        }

    }
}
