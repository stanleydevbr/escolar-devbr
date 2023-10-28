using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Funcionarios;
using DevBr.Escola.Dominio.Interfaces.Repositories.Funcionarios;
using DevBr.Escola.Infra.Data.Context;
using DevBr.Escola.Infra.Data.Repositories.Base;

namespace DevBr.Escola.Infra.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public IRepositoryCore<Atividade> Atividade { get; set; }
        public IRepositoryCore<Cargo> Cargo { get; set; }
        public FuncionarioRepository(EscolaContext context) : base(context)
        {
        }
    }
}
