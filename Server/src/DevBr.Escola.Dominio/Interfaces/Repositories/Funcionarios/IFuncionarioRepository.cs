using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Funcionarios;

namespace DevBr.Escola.Dominio.Interfaces.Repositories.Funcionarios
{
    public interface IFuncionarioRepository : IRepositoryCore<Funcionario>
    {
        public IRepositoryCore<Atividade> Atividade { get; set; }
        public IRepositoryCore<Cargo> Cargo { get; set; }
    }
}
