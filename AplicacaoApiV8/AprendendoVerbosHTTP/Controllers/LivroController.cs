using AprendendoVerbosHTTP.Business;
using AprendendoVerbosHTTP.Data.VO;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(List<LivroVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get()
        {
            var livros = _livroBusiness.FindAll();
            if (livros == null || livros.Count == 0) return NoContent();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(LivroVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult Get(int ID)
        {
            var livro = _livroBusiness.FindById(ID);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        [Authorize("Bearer")]
        [SwaggerResponse((201), Type = typeof(LivroVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Post(LivroVO livro)
        {
            if (livro == null) return BadRequest();
            return Created("api/v1/livro",_livroBusiness.Create(livro));
        }

        [HttpPut]
        [Authorize("Bearer")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult Put(LivroVO livro)
        {
            var livroUpdate = _livroBusiness.Update(livro);
            if (livroUpdate == null) return NotFound();
            return NoContent();
        }

        [HttpPatch]
        [Authorize("Bearer")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult Patch(LivroVO livro)
        {
            var livroUpdate = _livroBusiness.Update(livro);
            if (livroUpdate == null) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [Authorize("Bearer")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult Delete(int ID)
        {
            if (!_livroBusiness.Delete(ID)) return NotFound();
            return NoContent();
        }
    }
}