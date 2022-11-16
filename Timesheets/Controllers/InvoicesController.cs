using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models.Request;

namespace Timesheets.Controllers
{
    public class InvoicesController : TimesheetBaseController
    {
        private readonly IContractManager _contractManager;
        private readonly IInvoiceManager _invoiceManager;

        public InvoicesController(IContractManager contractManager, IInvoiceManager invoiceManager)
        {
            _contractManager = contractManager;
            _invoiceManager = invoiceManager;
        }

        /// <summary>
        /// Создает клиентский счёт
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest invoice)
        {
            if (await IsAllowedToCreate(invoice))
            {
                return BadRequest($"Contract {invoice.ContractId} is not active or not found!");
            }

            var id = await _invoiceManager.Create(invoice);

            return Ok(id);

        }

        private async Task<bool> IsAllowedToCreate(InvoiceRequest invoice)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(invoice.ContractId);

            return isAllowedToCreate == null || (bool)!isAllowedToCreate;
        }
    }
}
