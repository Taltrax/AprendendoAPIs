using AprendendoVerbosHTTP.Business;
using AprendendoVerbosHTTP.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AprendendoVerbosHTTP.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _business;

        public LoginController(ILoginBusiness business)
        {
            _business = business;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            if (usuario == null) return BadRequest();
            return new ObjectResult(_business.FindByLogin(usuario));
        }
    }
}