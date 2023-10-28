using DevBr.Escola.Dominio.Entidades.Matriculas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBr.Escola.Infra.Data.Configuration.Matriculas
{
    public class PeriodoConfig : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.ToTable("Periodos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.AnoLetivo)
                .IsRequired();

            builder.Property(x => x.InicioMatricula)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.TerminoMatricula)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.InicioAnoLetivo)
                .HasColumnType("DateTime");

            builder.Property(x => x.TerminoAnoLetivo)
                .HasColumnType("DateTime");

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
