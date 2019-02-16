using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AprendendoVerbosHTTP.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PessoaController : ControllerBase
    {

        public IPessoaBusiness _pessoaBusiness;

        public PessoaController(IPessoaBusiness pessoaBusiness)
        {
            _pessoaBusiness = pessoaBusiness;
        }

        // GET api/v1/pessoa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }

        // GET api/v1/pessoa/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaBusiness.FindById(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        // POST api/v1/pessoa
        [HttpPost]
        public ActionResult Post(Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaBusiness.Create(pessoa));
            
        }

        // PUT api/v1/pessoa/5
        [HttpPut]
        public ActionResult Put(Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            var pessoaAtualizada = _pessoaBusiness.Update(pessoa);
            if (pessoaAtualizada == null) return NotFound();
            return new ObjectResult(pessoaAtualizada);
        }

        // DELETE api/v1/pessoa/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _pessoaBusiness.Delete(id);
            return NoContent();
        }
    }
}
