using MeuProjetoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuProjetoApi.BancoDados.Configs
{
    public class BandaConfig : IEntityTypeConfiguration<Banda>
    {
        public void Configure(EntityTypeBuilder<Banda> builder)
        {
            builder.ToTable("Banda"); // Nome da tabela no banco de dados

            // Mapeamento das propriedades
            builder.Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.GeneroMusical)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Descricao)
                .HasMaxLength(500);

            builder.Property(b => b.Imagem);

        }
    }
}