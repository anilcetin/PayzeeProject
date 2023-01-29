using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacitonsController : ControllerBase
    {
        ITransactionService _transactionService;

        public TransacitonsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("add")]
        public IActionResult Add(Transaction transaction)
        {
            _transactionService.Add(transaction);
            return Ok();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transactionService.GetAll();

            return Ok(result);

        }
    }
}
