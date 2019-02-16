using AprendendoVerbosHTTP.Business;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            var livros = _livroBusiness.FindAll();

            if (livros == null) return NoContent();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            var livro = _livroBusiness.FindById(ID);

            if (livro == null) return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Post(LivroVO livro)
        {
            if (livro == null) return BadRequest();
            return new ObjectResult(_livroBusiness.Create(livro));
        }

        [HttpPut]
        public IActionResult Put(LivroVO livro)
        {
            var livroUpdate = _livroBusiness.Update(livro);

            if (livroUpdate == null) return NotFound();

            return Ok(livroUpdate);
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            if (!_livroBusiness.Delete(ID)) return NotFound();
            return NoContent();
        }


    }
}