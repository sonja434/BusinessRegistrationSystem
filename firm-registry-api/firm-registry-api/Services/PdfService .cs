using firm_registry_api.Models;
using firm_registry_api.Services.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace firm_registry_api.Services
{
    public class PdfService : IPdfService
    {
        public Task<byte[]> GenerateCompanyRequestPdfAsync(CompanyRequest request)
        {
            var pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Text($"Zahtev za registraciju firme: {request.CompanyName ?? "Nije uneto"}")
                        .SemiBold()
                        .FontSize(16)
                        .FontColor(Colors.Blue.Medium);

                    page.Content()
                        .Column(col =>
                        {
                            col.Item().Text($"Tip firme: {request.Type}");
                            col.Item().Text($"Status zahteva: {request.Status}");
                            col.Item().Text($"Aktivnost: {request.ActivityCode?.Code ?? "N/A"} - {request.ActivityCode?.Description ?? "N/A"}");
                            col.Item().Text($"Adresa: {request.Address?.Street ?? "N/A"} {request.Address?.Number}, {request.Address?.City ?? "N/A"}, {request.Address?.Country ?? "N/A"}");
                            col.Item().Text($"Korisnik: {request.User?.FirstName ?? ""} {request.User?.LastName ?? ""} ({request.User?.Email ?? "N/A"})");
                            col.Item().Text($"Datum kreiranja: {request.CreatedAt:dd.MM.yyyy HH:mm}");
                            col.Item().Text($"Datum poslednje izmene: {request.UpdatedAt:dd.MM.yyyy HH:mm}");

                            if (request is EntrepreneurRequest entrepreneur)
                            {
                                col.Item().Text($"Vlasnik: {entrepreneur.Owner?.FirstName ?? ""} {entrepreneur.Owner?.LastName ?? ""}");
                            }
                            else if (request is LimitedCompanyRequest limited)
                            {
                                col.Item().Text($"Direktor: {limited.DirectorFullName ?? "N/A"}");
                                col.Item().Text($"Osnivači: {string.Join(", ", limited.Founders?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                            }
                            else if (request is JointStockCompanyRequest joint)
                            {
                                col.Item().Text($"Akcionari: {string.Join(", ", joint.Shareholders?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                                col.Item().Text($"Upravni odbor: {string.Join(", ", joint.BoardOfDirectors ?? new List<string>())}");
                            }
                            else if (request is LimitedPartnershipRequest lp)
                            {
                                col.Item().Text($"Generalni partneri: {string.Join(", ", lp.GeneralPartners?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                                col.Item().Text($"Limitirani partneri: {string.Join(", ", lp.LimitedPartners?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                            }
                            else if (request is PartnershipRequest pr)
                            {
                                col.Item().Text($"Partneri: {string.Join(", ", pr.Partners?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                            }

                            if (request.Documents != null && request.Documents.Any())
                            {
                                col.Item().Text("Dokumenti priloženi:");
                                col.Item().Column(docCol =>
                                {
                                    foreach (var doc in request.Documents)
                                        docCol.Item().Text($"- {doc}");
                                });
                            }

                            if (!string.IsNullOrWhiteSpace(request.AdminNotes))
                                col.Item().Text($"Napomena od admina: {request.AdminNotes}");
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Firma Registry API – PDF generisano ");
                            x.Span($"{DateTime.Now:dd.MM.yyyy HH:mm}");
                        });
                });
            }).GeneratePdf();

            return Task.FromResult(pdfBytes);
        }
    }
}
