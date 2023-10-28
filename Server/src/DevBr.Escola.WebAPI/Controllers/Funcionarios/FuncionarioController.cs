using DevBr.Core.API;
using DevBr.Core.API.Usuario;
using DevBr.Escola.Aplicacao.Interfaces.Funcionarios;
using DevBr.Escola.Dominio.ViewModels.Funcionarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBr.Escola.WebAPI.Controllers.Funcionarios
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerCore<FuncionarioViewModel>
    {
        private readonly new IFuncionarioApp AppService;
        public FuncionarioController(IFuncionarioApp appService, IAspNetUser appUser) : base(appService, appUser)
        {
            AppService = appService;
        }
    }
}
