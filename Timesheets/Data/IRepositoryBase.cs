using System;
using System.Collections.Generic;

namespace Timesheets.Data
{
    public interface IRepositoryBase<T>
    {
        T GetItem(Guid id);
        IEnumerable<T> GetItems();
        void Add(T item);
        void Update();
    }
}
