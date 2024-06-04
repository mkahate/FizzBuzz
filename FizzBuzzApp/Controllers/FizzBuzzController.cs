using FizzBuzzApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FizzBuzzApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly FizzBuzzService _fizzBuzzService;

        public FizzBuzzController(FizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public IActionResult ProcessValues(object[] values)
        {
            var results = _fizzBuzzService.Process(values);
            return Ok(results);
        }
    }
}
