using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

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
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(List<PessoaVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get()
        {
            var pessoas = _pessoaBusiness.FindAll();
            if (pessoas == null || pessoas.Count == 0) return NoContent();
            return Ok(pessoas);
        }

        // GET api/v1/pessoa/{id}
        [HttpGet("{id}")]
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(PessoaVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaBusiness.FindById(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        // GET api/v1/pessoa/
        [HttpGet("nome")]
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(List<PessoaVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult Get(string nome, string sobrenome)
        {
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(sobrenome)) return BadRequest();
           
            var pessoas = _pessoaBusiness.FindByName(nome, sobrenome);
            if (pessoas == null || pessoas.Count == 0) return NotFound();
            return Ok(pessoas);
        }

        // POST api/v1/pessoa
        [HttpPost]
        [Authorize("Bearer")]
        [SwaggerResponse((201), Type = typeof(PessoaVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public ActionResult Post(PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Created("api/v1/pessoa", _pessoaBusiness.Create(pessoa));
            
        }

        // PUT api/v1/pessoa/
        [HttpPut]
        [Authorize("Bearer")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public ActionResult Put(PessoaVO pessoa)
        {
            var pessoaAtualizada = _pessoaBusiness.Update(pessoa);
            if (pessoaAtualizada == null) return NotFound();
            return NoContent();
        }

        // PATCH api/v1/pessoa/
        [HttpPatch]
        [Authorize("Bearer")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public ActionResult Patch(PessoaVO pessoa)
        {
            var pessoaAtualizada = _pessoaBusiness.Update(pessoa);
            if (pessoaAtualizada == null) return NotFound();
            return NoContent();
        }

        // DELETE api/v1/pessoa/{id}
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public ActionResult Delete(int id)
        {
            if (!_pessoaBusiness.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}
