using DevBr.Escola.Dominio.Entidades.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBr.Escola.Infra.Data.Configuration.Funcionarios
{
    public class FuncionarioConfig : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {

            builder.ToTable("Funcionarios");

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

            builder.Property(x => x.Telefone)
                .HasMaxLength(13);

            builder.Property(x => x.Celular)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.Property(x => x.Identidade)
                .HasMaxLength(30);

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.Salario);

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
