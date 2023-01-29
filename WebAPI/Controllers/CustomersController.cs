using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Thread.Sleep(3000);

            var result = _customerService.GetAll();

            return Ok(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok();
        }
    }
}
