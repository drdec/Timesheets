using System;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Domain.Implementation
{
    public class ContractManager : IContractManager
    {
        private readonly IContractRepository _contractRepository;

        public ContractManager(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            return await _contractRepository.CheckContractIsActive(id);

        }
    }
}
