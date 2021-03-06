﻿using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace AprendendoVerbosHTTP.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PessoaController : ControllerBase
    {

        IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET api/v1/pessoa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaService.FindAll());
        }

        // GET api/v1/pessoa/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaService.FindById(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        // POST api/v1/pessoa
        [HttpPost]
        public ActionResult Post(Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Create(pessoa));
            
        }

        // PUT api/v1/pessoa/5
        [HttpPut("{id}")]
        public ActionResult Put(Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Update(pessoa));
        }

        // DELETE api/v1/pessoa/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _pessoaService.Delete(id);
            return NoContent();
        }
    }
}
