
using NetworkMarketing.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.DB.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            ItemRepository = new ItemRepository(_dataContext);
            DistributorRepository = new DistributorRepository(_dataContext);
            SalesOrderRepository = new SalesOrderRepository(_dataContext);
        }

        public IItemRepository ItemRepository { get; }
        public IDistributorRepository DistributorRepository { get; }
        public ISalesOrderRepository SalesOrderRepository { get; }

        public void Complete()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
