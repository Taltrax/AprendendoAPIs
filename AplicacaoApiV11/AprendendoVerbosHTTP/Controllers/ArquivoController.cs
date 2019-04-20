using AprendendoVerbosHTTP.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AprendendoVerbosHTTP.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArquivoController : ControllerBase
    {
        private IArquivoBusiness _business;

        public ArquivoController(IArquivoBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(byte[]))]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public IActionResult GetPDFFile()
        {
            byte[] buffer = _business.GetPDFFile();

            if(buffer != null)
            {
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
            }

            return new ContentResult();
        }
    }
}