using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Dtos.SalesOrderDtos
{
    public class CreateSalesOrderRowDto
    {
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
    }
}
