using DevBr.Core.API.Usuario;
using DevBr.Core.Aplicacao.Interfaces;
using DevBr.Core.Dominio.Entidades;
using DevBr.Core.Dominio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevBr.Core.API
{
    public class ControllerCore<TViewModel> : ControllerCore where TViewModel : ViewModelCore
    {
        protected IAppServiceCore<TViewModel> AppService { get; set; }

        public ControllerCore(IAppServiceCore<TViewModel> appService, IAspNetUser appUser) : base(appUser)
        {
            AppService = appService;
        }

        [HttpPost("Adicionar")]
        public virtual async Task<IActionResult> AdicionarAsync([FromBody] TViewModel servico)
        {
            return ModelState.IsValid ? TrateResultado(await AppService.AdicionarAsync(servico)) : BadRequest(ModelState);
        }

        [HttpPut("Editar")]
        public virtual async Task<IActionResult> EditarAsync([FromBody] TViewModel servico)
        {
            return ModelState.IsValid ? TrateResultado(await AppService.EditarAsync(servico)) : BadRequest(ModelState);
        }

        [HttpDelete("Excluir/{id}")]
        public virtual async Task<IActionResult> ExcluirAsync(Guid id)
        {
            return Ok(await AppService.ExcluirAsync(id));
        }

        [HttpGet("Consultar/{id}")]
        public virtual async Task<IActionResult> ConsultarAsync(Guid id)
        {
            var servico = await AppService.ConsultarAsync(id);
            return TrateResultado(servico);
        }

        [HttpGet("Listar")]
        public virtual async Task<IActionResult> ListarAsync()
        {
            try
            {
                return Ok(await AppService.ListarAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($" {ex.Message} ");
            }
        }

        [HttpGet]
        [Route("ListarComFiltro")]
        public virtual async Task<IActionResult> ListarAsync([FromQuery] FilterList filtro)
        {
            try
            {
                return Ok(await AppService.ListarAsync(filtro));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
