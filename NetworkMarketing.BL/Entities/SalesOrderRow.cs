using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Entities
{
    public class SalesOrderRow
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal LineTotal { get; set; }
    }
}
