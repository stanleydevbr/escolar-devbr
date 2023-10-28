using DevBr.Escola.Dominio.Entidades.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBr.Escola.Infra.Data.Configuration.Empresas
{
    public class SalaConfig : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {

            builder.ToTable("Salas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.Capacidade)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.UsuarioCriacao)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.DataAlteracao)
                .HasColumnType("DateTime");

            builder.Property(x => x.UsuarioAlteracao)
                .HasMaxLength(40);

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);

        }
    }
}
