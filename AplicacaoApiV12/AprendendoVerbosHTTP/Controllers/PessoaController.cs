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

        [HttpGet]
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(List<PessoaVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult Get()
        {
            var pessoas = _pessoaBusiness.FindAll();
            if (pessoas == null || pessoas.Count == 0) return NotFound();
            return Ok(pessoas);
        }

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

        [HttpGet("{ordenacao}/{tamLimite}/{pagina}")]
        [Authorize("Bearer")]
        [SwaggerResponse((200), Type = typeof(List<PessoaVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public IActionResult GetByPagedSearch(string nome, string ordenacao, int tamLimite, int pagina)
        {
            var respostaPaginada = _pessoaBusiness.FindWithPagedSearch(nome, ordenacao, tamLimite, pagina);
            if (respostaPaginada == null) return NotFound();
            return Ok(respostaPaginada);
        }

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
