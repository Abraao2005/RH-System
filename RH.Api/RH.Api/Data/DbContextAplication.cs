using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using RH.Api.Models;

namespace RH.Api.Data
{
    public class DbContextAplication : DbContext
    {

        public DbContextAplication(DbContextOptions<DbContextAplication> options) : base(options)
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<FeriasModel> Ferias { get; set; }
        public DbSet<HistoricoModel> Historicos { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var historicos = new List<HistoricoModel>();

            foreach (var entry in ChangeTracker.Entries()
                                                 .Where(e => e.State == EntityState.Modified))
            {
                var nomeEntidade = entry.Entity.GetType().Name;

                var pk = entry.Metadata.FindPrimaryKey()?.Properties.FirstOrDefault();
                if (pk == null) continue;  

                var rawValue = entry.Property(pk.Name).CurrentValue;
                if (rawValue == null) continue;
                if (!int.TryParse(rawValue.ToString(), out var registroChave))
                    continue;

                foreach (var prop in entry.Properties)
                {
                    var original = prop.OriginalValue?.ToString() ?? "";
                    var atual = prop.CurrentValue?.ToString() ?? "";

                    if (original == atual)
                        continue; 

                    historicos.Add(new HistoricoModel
                    {
                        NomeEntidade = nomeEntidade,
                        RegistroChave = registroChave,
                        CampoAlterado = prop.Metadata.Name,
                        ValorAntigo = original,
                        ValorNovo = atual,
                        DataHora = DateTime.UtcNow
                    });
                }
            }

            // Se houver historicos, adiciona todos
            if (historicos.Any())
                await Set<HistoricoModel>()
                      .AddRangeAsync(historicos, cancellationToken);

            // Finalmente salva tudo (entidades + históricos)
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}


