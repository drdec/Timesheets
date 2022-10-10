using System;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IContractRepository : IRepositoryBase<Contract>
    {
        Task<bool?> CheckContractIsActive(Guid id);
    }
}
