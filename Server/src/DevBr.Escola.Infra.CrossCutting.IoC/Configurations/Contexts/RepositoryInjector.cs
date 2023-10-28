using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Infra.Data.UoW;
using DevBr.Escola.Dominio.Entidades.Alunos;
using DevBr.Escola.Dominio.Entidades.Empresas;
using DevBr.Escola.Dominio.Entidades.Funcionarios;
using DevBr.Escola.Dominio.Entidades.Matriculas;
using DevBr.Escola.Dominio.Interfaces.Repositories.Alunos;
using DevBr.Escola.Dominio.Interfaces.Repositories.Cursos;
using DevBr.Escola.Dominio.Interfaces.Repositories.Empresas;
using DevBr.Escola.Dominio.Interfaces.Repositories.Funcionarios;
using DevBr.Escola.Dominio.Interfaces.Repositories.Matriculas;
using DevBr.Escola.Infra.Data.Context;
using DevBr.Escola.Infra.Data.Repositories;
using DevBr.Escola.Infra.Data.Repositories.Base;
using DevBr.Escola.Infra.Data.Repositories.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevBr.Escola.Infra.CrossCutting.IoC.Configurations.Contexts
{
    public static class RepositoryInjector
    {
        public static void ResolverDependencyRepository(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<EscolaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddTransient<DbContext, EscolaContext>();
            service.AddTransient<IAlunoRepository, AlunoRepository>();
            service.AddTransient<IRepositoryCore<Doenca>, BaseRepository<Doenca>>();
            service.AddTransient<IRepositoryCore<FichaMedica>, BaseRepository<FichaMedica>>();
            service.AddTransient<IRepositoryCore<Hospital>, BaseRepository<Hospital>>();
            service.AddTransient<IRepositoryCore<Medicacao>, BaseRepository<Medicacao>>();
            service.AddTransient<IRepositoryCore<Medico>, BaseRepository<Medico>>();

            service.AddTransient<ICursoRepository, CursoRepository>();
            service.AddTransient<IDisciplinaRepository, DisciplinaRepository>();

            service.AddTransient<IEmpresaRepository, EmpresaRepository>();
            service.AddTransient<IRepositoryCore<Recurso>, BaseRepository<Recurso>>();
            service.AddTransient<IRepositoryCore<Sala>, BaseRepository<Sala>>();

            service.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            service.AddTransient<IRepositoryCore<Atividade>, BaseRepository<Atividade>>();
            service.AddTransient<IRepositoryCore<Cargo>, BaseRepository<Cargo>>();

            service.AddTransient<IMatriculaRepository, MatriculaRepository>();
            service.AddTransient<IRepositoryCore<Periodo>, BaseRepository<Periodo>>();
            service.AddTransient<IRepositoryCore<Turma>, BaseRepository<Turma>>();
        }
    }
}
