using DevBr.Core.API;
using DevBr.Core.API.Usuario;
using DevBr.Escola.Aplicacao.Interfaces.Cursos;
using DevBr.Escola.Dominio.ViewModels.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBr.Escola.WebAPI.Controllers.Cursos
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerCore<DisciplinaViewModel>
    {
        private readonly new IDisciplinaApp AppService;
        public DisciplinaController(IDisciplinaApp appService, IAspNetUser appUser, IHttpContextAccessor httpContextAccessor) : base(appService, appUser)
        {
            AppService = appService;
        }
    }
}
