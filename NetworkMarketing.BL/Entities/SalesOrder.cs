using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Entities
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public Distributor Distributor { get; set; }
        public int DistributorId { get; set; }
        public DateTime PostingDate { get; set; }
        public IEnumerable<SalesOrderRow> Rows { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
