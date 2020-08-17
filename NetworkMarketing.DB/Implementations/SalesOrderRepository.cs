using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.DB.Implementations
{
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(DataContext context) : base(context)
        {

        }

        private DataContext SalesOrderContext => Context as DataContext;
    }
}
