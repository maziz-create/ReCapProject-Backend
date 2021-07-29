using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksController : ControllerBase
    {
        private readonly IFindeksService _findeksService;

        public FindeksController(IFindeksService findeksService)
        {
            _findeksService = findeksService;
        }

        [HttpPost("add")]
        public IActionResult Add(Findeks findeks)
        {
            var result = _findeksService.Add(findeks);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Findeks findeks)
        {
            var result = _findeksService.Delete(findeks);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _findeksService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _findeksService.GetByCustomerId(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
