using CaseStudy.Entities;
using CaseStudy.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CaseStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] Transaction transaction)
        {
            var createdTransaction = await _transactionService.PayAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id = createdTransaction.Id }, createdTransaction);
        }

        [HttpPost("cancel/{transactionId}")]
        public async Task<IActionResult> Cancel(Guid transactionId)
        {
            var canceledTransaction = await _transactionService.CancelAsync(transactionId);
            return Ok(canceledTransaction);
        }

        [HttpPost("refund/{transactionId}")]
        public async Task<IActionResult> Refund(Guid transactionId)
        {
            var refundedTransaction = await _transactionService.RefundAsync(transactionId);
            return Ok(refundedTransaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
    }

}
