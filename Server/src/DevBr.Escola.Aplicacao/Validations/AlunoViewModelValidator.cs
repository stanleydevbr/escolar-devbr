using DevBr.Escola.Dominio.ViewModels.Alunos;
using FluentValidation;

namespace DevBr.Escola.Aplicacao.Validations
{
    //TODO: Exemplo de solução com fluent-validator
    public class AlunoViewModelValidator : AbstractValidator<AlunoViewModel>
    {
        public AlunoViewModelValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.SobreNome).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
