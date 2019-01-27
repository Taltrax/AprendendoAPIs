using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace AprendendoVerbosHTTP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaService.FindById(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post(Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Create(pessoa));
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Update(pessoa));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _pessoaService.Delete(id);
            return NoContent();
        }
    }
}
