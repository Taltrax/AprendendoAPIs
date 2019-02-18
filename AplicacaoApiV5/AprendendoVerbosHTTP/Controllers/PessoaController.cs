using AprendendoVerbosHTTP.Data.Converters;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Repository;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;

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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }

        // GET api/v1/pessoa/5
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaBusiness.FindById(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        // POST api/v1/pessoa
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post(PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaBusiness.Create(pessoa));
            
        }

        // PUT api/v1/pessoa/
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put(PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            var pessoaAtualizada = _pessoaBusiness.Update(pessoa);
            if (pessoaAtualizada == null) return NotFound();
            return new ObjectResult(pessoaAtualizada);
        }

        // DELETE api/v1/pessoa/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(int id)
        {
            if (!_pessoaBusiness.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}
