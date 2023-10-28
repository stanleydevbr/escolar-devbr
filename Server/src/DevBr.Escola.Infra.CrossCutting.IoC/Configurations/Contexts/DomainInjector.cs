using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Dominio.Services;
using DevBr.Escola.Dominio.Entidades.Alunos;
using DevBr.Escola.Dominio.Entidades.Empresas;
using DevBr.Escola.Dominio.Entidades.Funcionarios;
using DevBr.Escola.Dominio.Entidades.Matriculas;
using DevBr.Escola.Dominio.Interfaces.Services.Alunos;
using DevBr.Escola.Dominio.Interfaces.Services.Cursos;
using DevBr.Escola.Dominio.Interfaces.Services.Empresas;
using DevBr.Escola.Dominio.Interfaces.Services.Funcionarios;
using DevBr.Escola.Dominio.Interfaces.Services.Matriculas;
using DevBr.Escola.Dominio.Services.Alunos;
using DevBr.Escola.Dominio.Services.Cursos;
using DevBr.Escola.Dominio.Services.Empresas;
using DevBr.Escola.Dominio.Services.Funcionarios;
using DevBr.Escola.Dominio.Services.Matriculas;
using Microsoft.Extensions.DependencyInjection;

namespace DevBr.Escola.Infra.CrossCutting.IoC.Configurations.Contexts
{
    public static class DomainInjector
    {
        public static void ResolverDependencyDomain(this IServiceCollection service)
        {
            //Contexto Aluno
            service.AddTransient<IAlunoService, AlunoService>();
            service.AddTransient<IServiceCore<Doenca>, ServiceCore<Doenca>>();
            service.AddTransient<IServiceCore<FichaMedica>, ServiceCore<FichaMedica>>();
            service.AddTransient<IServiceCore<Hospital>, ServiceCore<Hospital>>();
            service.AddTransient<IServiceCore<Medicacao>, ServiceCore<Medicacao>>();
            service.AddTransient<IServiceCore<Medico>, ServiceCore<Medico>>();

            //Contexto Curso
            service.AddTransient<ICursoService, CursoService>();
            service.AddTransient<IDisciplinaService, DisciplinaService>();

            //Contexto Empresa
            service.AddTransient<IEmpresaService, EmpresaService>();
            service.AddTransient<IServiceCore<Recurso>, ServiceCore<Recurso>>();
            service.AddTransient<IServiceCore<Sala>, ServiceCore<Sala>>();

            //Contexto Funcionario
            service.AddTransient<IFuncionarioService, FuncionarioService>();
            service.AddTransient<IServiceCore<Cargo>, ServiceCore<Cargo>>();
            service.AddTransient<IServiceCore<Atividade>, ServiceCore<Atividade>>();

            //Contexto Matricula
            service.AddTransient<IMatriculaService, MatriculaService>();
            service.AddTransient<IServiceCore<Periodo>, ServiceCore<Periodo>>();
            service.AddTransient<IServiceCore<Turma>, ServiceCore<Turma>>();

        }
    }
}
