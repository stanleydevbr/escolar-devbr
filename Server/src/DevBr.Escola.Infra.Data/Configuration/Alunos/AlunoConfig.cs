using DevBr.Escola.Dominio.Entidades.Alunos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBr.Escola.Infra.Data.Configuration.Alunos
{
    public class AlunoConfig : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.SobreNome)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.Genero)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Identidade)
                .HasMaxLength(25);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.NomeDoPai)
                .HasMaxLength(120);

            builder.Property(x => x.NomeDaMae)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Celular)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.EscolaOrigem)
                .HasMaxLength(120);

            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.UsuarioCriacao)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.DataAlteracao).HasColumnType("DateTime");

            builder.Property(x => x.UsuarioAlteracao)
                .HasMaxLength(40);

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);

        }
    }
}
