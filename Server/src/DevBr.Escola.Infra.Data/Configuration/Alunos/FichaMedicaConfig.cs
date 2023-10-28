using DevBr.Escola.Dominio.Entidades.Alunos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBr.Escola.Infra.Data.Configuration.Alunos
{
    class FichaMedicaConfig : IEntityTypeConfiguration<FichaMedica>
    {
        public void Configure(EntityTypeBuilder<FichaMedica> builder)
        {

            builder.ToTable("FichasMedicas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd();


            builder.Property(x => x.TipoSanguineo)
                .HasMaxLength(30);

            builder.Property(x => x.Observacao)
                .HasMaxLength(500);

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
