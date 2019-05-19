using AprendendoVerbosHTTP.Business;
using AprendendoVerbosHTTP.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

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

        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        public IActionResult Post(UsuarioVO usuario)
        {
            return Created("api/v1/login", _business.FindByLogin(usuario));
        }
    }
}