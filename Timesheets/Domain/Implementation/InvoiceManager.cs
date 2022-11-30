using System;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Request;

namespace Timesheets.Domain.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly ISheetRepository _sheetRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceManager(ISheetRepository sheetRepository, IInvoiceRepository invoiceRepository)
        {
            _sheetRepository = sheetRepository;
            _invoiceRepository = invoiceRepository;
        }

        private const int Rate = 100;

        public async Task<Guid> Create(InvoiceRequest invoiceRequest)
        {
            var sheets = await _sheetRepository.GetItemsForInvoice(
                invoiceRequest.ContractId,
                invoiceRequest.DateStart,
                invoiceRequest.DateEnd);

            var invoice = new Invoice()
            {
                Id = Guid.NewGuid(),
                ContractId = invoiceRequest.ContractId,
                DateEnd = invoiceRequest.DateEnd,
                DateStart = invoiceRequest.DateStart
            };

            invoice.Sheet.AddRange(sheets);
            invoice.Sum = invoice.Sheet.Sum(x => x.Amount * Rate);

            await _invoiceRepository.Add(invoice);

            return invoice.Id;
        }
    }
}
