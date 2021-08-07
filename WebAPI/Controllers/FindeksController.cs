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
        private readonly ICustomerService _customerService;

        public FindeksController(IFindeksService findeksService, ICustomerService customerService)
        {
            _findeksService = findeksService;
            _customerService = customerService;
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

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var customer = _customerService.GetByUserId(userId);
            var result = _findeksService.GetByCustomerId(customer.Data.Id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
