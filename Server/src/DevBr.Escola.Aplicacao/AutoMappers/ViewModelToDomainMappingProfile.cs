using AutoMapper;
using DevBr.Escola.Dominio.Entidades.Alunos;
using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Entidades.Empresas;
using DevBr.Escola.Dominio.Entidades.Funcionarios;
using DevBr.Escola.Dominio.Entidades.Matriculas;
using DevBr.Escola.Dominio.ViewModels.Alunos;
using DevBr.Escola.Dominio.ViewModels.Cursos;
using DevBr.Escola.Dominio.ViewModels.Empresas;
using DevBr.Escola.Dominio.ViewModels.Funcionarios;
using DevBr.Escola.Dominio.ViewModels.Matriculas;

namespace DevBr.Escola.Aplicacao.AutoMappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //TODO: Exemplo de como mapear proprieade por propriedade
            //.ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular))

            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<DoencaViewModel, Doenca>();
            CreateMap<FichaMedicaViewModel, FichaMedica>();
            CreateMap<HospitalViewModel, Hospital>();
            CreateMap<MedicacaoViewModel, Medicacao>();
            CreateMap<MedicoViewModel, Medico>();

            CreateMap<CursoViewModel, Curso>();
            CreateMap<DisciplinaViewModel, Disciplina>();

            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<RecursoViewModel, Recurso>();
            CreateMap<SalaViewModel, Sala>();

            CreateMap<AtividadeViewModel, Atividade>();
            CreateMap<CargoViewModel, Cargo>();
            CreateMap<FuncionarioViewModel, Funcionario>();

            CreateMap<MatriculaViewModel, Matricula>();
            CreateMap<PeriodoViewModel, Periodo>();
            CreateMap<TurmaViewModel, Turma>();
        }

    }
}
