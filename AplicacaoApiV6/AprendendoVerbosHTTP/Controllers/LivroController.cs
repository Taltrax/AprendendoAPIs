using AprendendoVerbosHTTP.Business;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LivroController : ControllerBase
    {
        public ILivroBusiness _livroBusiness;

        public LivroController(ILivroBusiness livroBusiness)
        {
            _livroBusiness = livroBusiness;
        }

        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<LivroVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get()
        {
            var livros = _livroBusiness.FindAll();

            if (livros == null) return NoContent();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(LivroVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get(int ID)
        {
            var livro = _livroBusiness.FindById(ID);

            if (livro == null) return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        [SwaggerResponse((201), Type = typeof(LivroVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Post(LivroVO livro)
        {
            if (livro == null) return BadRequest();
            return new ObjectResult(_livroBusiness.Create(livro));
        }

        [HttpPut]
        [SwaggerResponse((202), Type = typeof(LivroVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Put(LivroVO livro)
        {
            var livroUpdate = _livroBusiness.Update(livro);

            if (livroUpdate == null) return NotFound();

            return Ok(livroUpdate);
        }

        [HttpDelete]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Delete(int ID)
        {
            if (!_livroBusiness.Delete(ID)) return NotFound();
            return NoContent();
        }


    }
}