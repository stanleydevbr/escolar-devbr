using DevBr.Core.API;
using DevBr.Core.API.Usuario;
using DevBr.Escola.Aplicacao.Interfaces.Alunos;
using DevBr.Escola.Dominio.ViewModels.Alunos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBr.Escola.WebAPI.Controllers.Alunos
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ValidateAntiForgeryToken]
    public class AlunoController : ControllerCore<AlunoViewModel>
    {
        private readonly new IAlunoApp AppService;
        public AlunoController(IAlunoApp appService, IAspNetUser appUser) : base(appService, appUser)
        {
            AppService = appService;
        }
    }
}
