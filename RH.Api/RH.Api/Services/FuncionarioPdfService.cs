using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using RH.Api.Models;
namespace RH.Api.Services
{
    public class FuncionarioPdfService : IDocument
    {
        public List<FuncionarioModel> Funcionarios { get; set; }

        public FuncionarioPdfService(List<FuncionarioModel> funcionarios)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            Funcionarios = funcionarios;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header().Text("Relatório de Funcionários")
                    .FontSize(20).Bold().AlignCenter();

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Nome").Bold();
                        header.Cell().Text("Cargo").Bold();
                        header.Cell().Text("Salário").Bold();
                        header.Cell().Text("Data de Admissão").Bold();
                        header.Cell().Text("Status do Funcionario").Bold();
                    });

                    foreach (var f in Funcionarios)
                    {
                        table.Cell().Text(f.Name);
                        table.Cell().Text(f.Office);
                        table.Cell().Text(f.Salary);
                        table.Cell().Text(f.DateAdmission.ToString("dd/MM/yyyy"));
                        table.Cell().Text(f.Active.Equals(true) ? "Ativo" : "Inativo");
                    }
                });

                page.Footer().AlignCenter().Text($"Total: {Funcionarios.Count} funcionários");
            });
        }
        public byte[] GerarPdf()
        {
            return this.GeneratePdf();

        }

    }
}
