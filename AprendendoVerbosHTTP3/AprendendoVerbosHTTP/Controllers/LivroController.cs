using AprendendoVerbosHTTP.Business;
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
        public IActionResult Post(Livro livro)
        {
            _livroBusiness.Create(livro);
            return Ok(livro);
        }

        [HttpPut]
        public IActionResult Put(Livro livro)
        {
            var livroUpdate = _livroBusiness.Update(livro);

            if (livroUpdate == null) return NotFound();

            return Ok(livroUpdate);
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            bool verifica = _livroBusiness.Delete(ID);
            if (!verifica) return NotFound();

            return NoContent();
        }


    }
}