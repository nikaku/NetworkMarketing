using Microsoft.EntityFrameworkCore;
using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NetworkMarketing.DB.Implementations
{
    public class DistributorRepository : Repository<Distributor>, IDistributorRepository
    {
        public DistributorRepository(DataContext context) : base(context)
        {

        }

        //public new Distributor Get(int id)
        //{
        //    return DistributorContext.Distributors.Where(x => x.Id == id).Include(x=>x.SalesOrders).FirstOrDefault();
        //}
        public new IEnumerable<Distributor> FindAll(Expression<Func<Distributor, bool>> predicate)
        {
            return Context.Set<Distributor>().Where(predicate).Include(x=>x.SalesOrders);
        }

        public new Distributor Find(Expression<Func<Distributor, bool>> predicate)
        {
            return Context.Set<Distributor>().Where(predicate).Include(x => x.SalesOrders).FirstOrDefault();
        }


        private DataContext DistributorContext => Context as DataContext;
    }
}
