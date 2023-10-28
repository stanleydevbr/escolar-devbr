using DevBr.Core.API;
using DevBr.Core.API.Usuario;
using DevBr.Escola.Aplicacao.Interfaces.Matriculas;
using DevBr.Escola.Dominio.ViewModels.Matriculas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBr.Escola.WebAPI.Controllers.Matriculas
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerCore<MatriculaViewModel>
    {
        private readonly new IMatriculaApp AppService;
        public MatriculaController(IMatriculaApp appService, IAspNetUser appUser) : base(appService, appUser)
        {
            AppService = appService;
        }
    }
}
