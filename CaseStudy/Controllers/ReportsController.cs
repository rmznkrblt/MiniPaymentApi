using CaseStudy.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseStudy.Controllers
{    

    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public ReportsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetReport(string bankId, string status, string orderReference, DateTime? startDate, DateTime? endDate)
        {
            var transactions = await _transactionRepository.GetAllAsync();

            // Filtreleme işlemleri burada gerçekleştirilebilir.
            // Örnek olarak:
            if (!string.IsNullOrEmpty(bankId))
                transactions = transactions.Where(t => t.BankId == bankId).ToList();

            // Diğer filtreler...

            return Ok(transactions);
        }
    }

}
