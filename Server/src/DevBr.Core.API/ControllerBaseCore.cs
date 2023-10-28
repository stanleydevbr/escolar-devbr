using DevBr.Core.API.Usuario;
using DevBr.Core.Dominio.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DevBr.Core.API
{
    public abstract class ControllerCore : ControllerBase
    {
        public readonly IAspNetUser AppUser;
        protected Guid UsuarioId { get; set; }
        public bool UsuarioAutenticado { get; set; }

        protected ControllerCore(IAspNetUser appUser)
        {
            AppUser = appUser;
            if (appUser.EstaAutenticado())
            {
                UsuarioId = appUser.ObterUserId();
                UsuarioAutenticado = true;
            }
        }

        protected virtual IActionResult TrateResultado(BaseViewModel model)
        {
            if (model == null)
                return NotFound();
            if (model.Inconsistencias == null || !model.Inconsistencias.Any()) return Ok(model);

            PopularModelStateComErros(model.Inconsistencias);

            return BadRequest(ModelState);
        }

        protected void PopularModelStateComErros(IEnumerable<string> mensagens)
        {
            foreach (var mensagem in mensagens)
                AdicionarErroModelState(mensagem);
        }

        protected void AdicionarErroModelState(string mensagem)
        {
            ModelState.AddModelError("Erros", mensagem);
        }
    }
}
