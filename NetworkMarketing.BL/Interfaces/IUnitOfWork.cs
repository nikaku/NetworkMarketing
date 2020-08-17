using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Interfaces
{
    public interface IUnitOfWork
    {
        void Complete();
        void Dispose();
        IItemRepository ItemRepository { get; }
        IDistributorRepository DistributorRepository { get; }
        ISalesOrderRepository SalesOrderRepository { get; }
    }
}
