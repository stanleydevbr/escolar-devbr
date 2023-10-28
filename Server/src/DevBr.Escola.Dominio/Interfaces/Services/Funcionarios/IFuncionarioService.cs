using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Funcionarios;

namespace DevBr.Escola.Dominio.Interfaces.Services.Funcionarios
{
    public interface IFuncionarioService : IServiceCore<Funcionario>
    {
        public IServiceCore<Atividade> AtividadeService { get; set; }
        public IServiceCore<Cargo> CargoService { get; set; }
    }


}
