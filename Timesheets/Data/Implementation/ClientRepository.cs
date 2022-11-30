using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{

    public class ClientRepository : IClientRepository
    {

        public async Task Add(Client item)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
