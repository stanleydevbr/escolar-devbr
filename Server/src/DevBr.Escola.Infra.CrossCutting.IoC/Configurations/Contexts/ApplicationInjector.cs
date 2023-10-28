using DevBr.Escola.Aplicacao.AppServices.Alunos;
using DevBr.Escola.Aplicacao.AppServices.Cursos;
using DevBr.Escola.Aplicacao.AppServices.Empresas;
using DevBr.Escola.Aplicacao.AppServices.Funcionarios;
using DevBr.Escola.Aplicacao.AppServices.Matriculas;
using DevBr.Escola.Aplicacao.Interfaces.Alunos;
using DevBr.Escola.Aplicacao.Interfaces.Cursos;
using DevBr.Escola.Aplicacao.Interfaces.Empresas;
using DevBr.Escola.Aplicacao.Interfaces.Funcionarios;
using DevBr.Escola.Aplicacao.Interfaces.Matriculas;
using Microsoft.Extensions.DependencyInjection;

namespace DevBr.Escola.Infra.CrossCutting.IoC.Configurations.Contexts
{
    public static class ApplicationInjector
    {
        public static void ResolverDependencyApplication(this IServiceCollection service)
        {
            service.AddTransient<IAlunoApp, AlunoApp>();

            service.AddTransient<ICursoApp, CursoApp>();
            service.AddTransient<IDisciplinaApp, DisciplinaApp>();

            service.AddTransient<IEmpresaApp, EmpresaApp>();

            service.AddTransient<IFuncionarioApp, FuncionarioApp>();

            service.AddTransient<IMatriculaApp, MatriculaApp>();
        }
    }
}
