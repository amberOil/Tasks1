using FibonacciAndRobot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourProjectName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        [HttpPost]
        public IActionResult CalculateFibonacci(FibonacciInputModel inputModel)
        {
            List<int> sequence = new List<int>();

            int a = 0;
            int b = 1;
            for (int i = 0; i < inputModel.SequenceLength; i++)
            {
                sequence.Add(a);
                int temp = a;
                a = b;
                b = temp + b;
            }

            string result = string.Join(",", sequence);
            return Ok(new FibonacciOutputModel { Sequence = result });
        }
    }
}