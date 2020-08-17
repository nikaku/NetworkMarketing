using NetworkMarketing.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkMarketing.BL.Entities
{
    public class DistributorLeaf : IDistributorComponent
    {
        public Distributor Distributor { get; set; }

        public decimal CalculateBonus()
        {
            //if (Distributor.ReferalLevel == 1)
            //{
            //    return Distributor.SalesOrders.Sum(x => x.TotalPrice)
            //}
            return 0;
        }
    }
}
