using System;
using System.Threading.Tasks;
using Timesheets.Models.Request;

namespace Timesheets.Domain.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Create(InvoiceRequest invoiceRequest);
    }
}
