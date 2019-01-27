using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AprendendoAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        [HttpGet("Soma/{numero1}/{numero2}")]
        public ActionResult Soma(string numero1, string numero2)
        {

            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                var total = ConvertDecimal(numero1) + ConvertDecimal(numero2);
                return Ok("Soma: " + total.ToString());
            }

            return BadRequest("Parâmetros inválidos");

        }

        [HttpGet("Subtracao/{numero1}/{numero2}")]
        public ActionResult Subtracao(string numero1, string numero2)
        {

            if(IsNumeric(numero1) && IsNumeric(numero2))
            {
                var total = ConvertDecimal(numero1) - ConvertDecimal(numero2);
                return Ok("Subtracao: " + total.ToString());
            }

            return BadRequest("Parâmetros inválidos");

        }

        [HttpGet("Multiplicacao/{numero1}/{numero2}")]
        public ActionResult Multiplicacao(string numero1, string numero2)
        {

            if(IsNumeric(numero1) && IsNumeric(numero2))
            {
                var total = ConvertDecimal(numero1) * ConvertDecimal(numero2);
                return Ok("Multiplicação: " + total.ToString());
            }

            return BadRequest("Parâmetros inválidos");

        }

        [HttpGet("Divisao/{numero1}/{numero2}")]
        public ActionResult Divisao(string numero1, string numero2)
        {

            if(IsNumeric(numero1) && IsNumeric(numero2))
            {
                var total = ConvertDecimal(numero1) / ConvertDecimal(numero2);
                return Ok("Divisão: " + total);
            }

            return BadRequest("Parâmetros inválidos");

        }

        public bool IsNumeric(string number)
        {

            bool isNumber = decimal.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out decimal numberParce);
            return isNumber;

        }

        public decimal ConvertDecimal(string numero)
        {
            if(decimal.TryParse(numero, out decimal numeroDecimal))
            {
                return numeroDecimal;
            }

            return 0;
        }

    }
}