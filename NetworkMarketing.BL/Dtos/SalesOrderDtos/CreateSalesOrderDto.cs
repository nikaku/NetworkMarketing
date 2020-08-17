using NetworkMarketing.BL.Dtos.ItemDtos;
using NetworkMarketing.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Dtos.SalesOrderDtos
{
    public class CreateSalesOrderDto
    {
        public int DistributorId { get; set; }
        public DateTime PostingDate { get; set; }
        public List<CreateSalesOrderRowDto> Rows { get; set; }
    }
}
