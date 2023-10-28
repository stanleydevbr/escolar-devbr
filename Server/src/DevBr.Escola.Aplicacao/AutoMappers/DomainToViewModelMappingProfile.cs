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
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<Doenca, DoencaViewModel>();
            CreateMap<FichaMedica, FichaMedicaViewModel>();
            CreateMap<Hospital, HospitalViewModel>();
            CreateMap<Medicacao, MedicacaoViewModel>();
            CreateMap<Medico, MedicoViewModel>();

            CreateMap<Curso, CursoViewModel>();
            CreateMap<Disciplina, DisciplinaViewModel>();

            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<Recurso, RecursoViewModel>();
            CreateMap<Sala, SalaViewModel>();

            CreateMap<Atividade, AtividadeViewModel>();
            CreateMap<Cargo, CargoViewModel>();
            CreateMap<Funcionario, FuncionarioViewModel>();

            CreateMap<Matricula, MatriculaViewModel>();
            CreateMap<Periodo, PeriodoViewModel>();
            CreateMap<Turma, TurmaViewModel>();
        }
    }
}
