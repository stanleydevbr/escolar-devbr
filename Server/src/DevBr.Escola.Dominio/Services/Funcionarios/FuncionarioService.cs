using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Dominio.Services;
using DevBr.Escola.Dominio.Entidades.Funcionarios;
using DevBr.Escola.Dominio.Interfaces.Repositories.Funcionarios;
using DevBr.Escola.Dominio.Interfaces.Services.Funcionarios;

namespace DevBr.Escola.Dominio.Services.Funcionarios
{
    public class FuncionarioService : ServiceCore<Funcionario>, IFuncionarioService
    {
        public IServiceCore<Atividade> AtividadeService { get; set; }
        public IServiceCore<Cargo> CargoService { get; set; }
        public FuncionarioService(IFuncionarioRepository repository) : base(repository)
        {
        }
    }

}
