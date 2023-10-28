using DevBr.Escola.Dominio.Entidades.Matriculas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBr.Escola.Infra.Data.Configuration.Matriculas
{
    public class MatriculaConfig : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {

            builder.ToTable("Matriculas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd();

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
