using firm_registry_api.Models;
using firm_registry_api.Services.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

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
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                    // HEADER
                    page.Header()
                        .PaddingBottom(10)
                        .BorderBottom(1)
                        .BorderColor(Colors.Grey.Medium)
                        .Row(row =>
                        {
                            row.RelativeColumn()
                                .Text("Agencija za privredne registre Republike Srbije")
                                .SemiBold().FontSize(14);

                            row.ConstantColumn(100)
                                .AlignRight()
                                .Text($"Datum: {DateTime.Now:dd.MM.yyyy}")
                                .FontSize(10);
                        });

                    // TITLE
                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        col.Item().AlignCenter().Text("Zahtev za registraciju firme")
                            .SemiBold().FontSize(16).FontColor(Colors.Blue.Medium);
                        col.Item().PaddingVertical(5);
                        col.Item().Text(text =>
                        {
                            text.Span("Naziv firme: ").SemiBold();
                            text.Span(request.CompanyName ?? "Nije uneto");
                        });

                        col.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                        // GENERAL INFO
                        col.Item().PaddingTop(10).Text("Opšte informacije:").SemiBold().FontSize(13);
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(4);
                            });

                            void AddRow(string label, string value)
                            {
                                table.Cell().Text(label).SemiBold();
                                table.Cell().Text(value);
                            }

                            AddRow("Tip firme:", request.Type.ToString());
                            AddRow("Status zahteva:", request.Status.ToString());
                            AddRow("Šifra delatnosti:", $"{request.ActivityCode?.Code ?? "N/A"} - {request.ActivityCode?.Description ?? "N/A"}");
                            AddRow("Adresa:",
                                $"{request.Address?.Street ?? "N/A"} {request.Address?.Number}, {request.Address?.City ?? "N/A"}, {request.Address?.Country ?? "N/A"}");
                            AddRow("Korisnik:",
                                $"{request.User?.FirstName ?? ""} {request.User?.LastName ?? ""} ({request.User?.Email ?? "N/A"})");
                            AddRow("Datum kreiranja:", $"{request.CreatedAt:dd.MM.yyyy HH:mm}");
                            AddRow("Datum izmene:", $"{request.UpdatedAt:dd.MM.yyyy HH:mm}");
                        });

                        // SPECIFIČNI PODACI
                        col.Item().PaddingTop(20).Text("Specifični podaci:").SemiBold().FontSize(13);
                        col.Item().Column(inner =>
                        {
                            if (request is EntrepreneurRequest entrepreneur)
                                inner.Item().Text($"Vlasnik: {entrepreneur.Owner?.FirstName} {entrepreneur.Owner?.LastName}");

                            else if (request is LimitedCompanyRequest limited)
                            {
                                inner.Item().Text($"Direktor: {limited.DirectorFullName ?? "N/A"}");
                                inner.Item().Text($"Osnivači: {string.Join(", ", limited.Founders?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                            }
                            else if (request is JointStockCompanyRequest joint)
                            {
                                inner.Item().Text($"Akcionari: {string.Join(", ", joint.Shareholders?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                                inner.Item().Text($"Upravni odbor: {string.Join(", ", joint.BoardOfDirectors ?? new List<string>())}");
                            }
                            else if (request is LimitedPartnershipRequest lp)
                            {
                                inner.Item().Text($"Generalni partneri: {string.Join(", ", lp.GeneralPartners?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                                inner.Item().Text($"Limitirani partneri: {string.Join(", ", lp.LimitedPartners?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                            }
                            else if (request is PartnershipRequest pr)
                                inner.Item().Text($"Partneri: {string.Join(", ", pr.Partners?.Select(f => $"{f.FirstName} {f.LastName}") ?? new List<string>())}");
                        });

                        // DOKUMENTI
                        if (request.Documents != null && request.Documents.Any())
                        {
                            col.Item().PaddingTop(20).Text("Priloženi dokumenti:").SemiBold().FontSize(13);
                            col.Item().Column(list =>
                            {
                                foreach (var doc in request.Documents)
                                    list.Item().Text($"• {doc}");
                            });
                        }

                        // ADMIN NAPOMENA
                        if (!string.IsNullOrWhiteSpace(request.AdminNotes))
                        {
                            col.Item().PaddingTop(20).Text("Napomena od administratora:").SemiBold().FontSize(13);
                            col.Item().Text(request.AdminNotes).Italic();
                        }
                    });

                    // FOOTER
                    page.Footer()
                        .AlignCenter()
                        .PaddingTop(10)
                        .BorderTop(1)
                        .BorderColor(Colors.Grey.Medium)
                        .Text($"Generisano automatski putem sistema – {DateTime.Now:dd.MM.yyyy HH:mm}");
                });
            }).GeneratePdf();

            return Task.FromResult(pdfBytes);
        }
    }
}
