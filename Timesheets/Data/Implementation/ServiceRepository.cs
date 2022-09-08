using System;
using System.Collections.Generic;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ServiceRepository : IServiceRepository
    {
        public void Add()
        {
            throw new System.NotImplementedException();
        }

        public Service GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
