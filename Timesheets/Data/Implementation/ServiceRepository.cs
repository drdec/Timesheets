using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ServiceRepository : IServiceRepository
    {
        public async Task Add(Service item)
        {
            throw new NotImplementedException();
        }

        public async Task<Service> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Service>> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public async Task Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
