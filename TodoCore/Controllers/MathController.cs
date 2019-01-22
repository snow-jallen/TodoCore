using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        /// <summary>
        /// https://localhost:5001/api/math?num1=5&num2=10
        /// </summary>
        /// <param name="num1">Any number</param>
        /// <param name="num2">any other number</param>
        /// <returns>the sum of the two numbers</returns>
        [HttpGet("Add")]
        public decimal Add([FromQuery]decimal num1, [FromQuery]decimal num2)
        {
            return num1 + num2;
        }

        [HttpGet("InterestCharge")]
        public decimal InterestCharge(decimal principal, decimal interestRate, decimal numDays)
        {
            return principal * interestRate / 365 * numDays;
        }
        
        [HttpGet("Concat")]
        public string Concat([FromQuery]string val1, [FromQuery]string val2)
        {
            return $"{val1}{val2}";
        }
    }
}