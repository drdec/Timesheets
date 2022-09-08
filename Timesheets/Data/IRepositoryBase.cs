using System;
using System.Collections.Generic;

namespace Timesheets.Data
{
    public interface IRepositoryBase<T>
    {
        T GetItem(Guid Id);
        IEnumerable<T> GetItems();
        void Add();
        void Update();
    }
}
