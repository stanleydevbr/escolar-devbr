using DevBr.Escola.Dominio.Entidades.Alunos;
using DevBr.Escola.Dominio.Interfaces.Repositories.Alunos;
using DevBr.Escola.Infra.Data.Context;
using DevBr.Escola.Infra.Data.Repositories.Base;

namespace DevBr.Escola.Infra.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        //public IRepositoryCore<Doenca> Doenca { get; set; }
        //public IRepositoryCore<FichaMedica> FichaMedica { get; set; }
        //public IRepositoryCore<Hospital> Hospital { get; set; }
        //public IRepositoryCore<Medicacao> Medicacao { get; set; }
        //public IRepositoryCore<Medico> Medico { get; set; }

        public AlunoRepository(EscolaContext context) : base(context)
        {

        }
    }
}
