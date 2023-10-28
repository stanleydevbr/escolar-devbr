using DevBr.Core.API;
using DevBr.Core.API.Usuario;
using DevBr.Escola.Aplicacao.Interfaces.Empresas;
using DevBr.Escola.Dominio.ViewModels.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevBr.Escola.WebAPI.Controllers.Empresas
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerCore<EmpresaViewModel>
    {
        private readonly new IEmpresaApp AppService;
        public EmpresaController(IEmpresaApp appService, IAspNetUser appUser) : base(appService, appUser)
        {
            AppService = appService;
        }
    }
}
