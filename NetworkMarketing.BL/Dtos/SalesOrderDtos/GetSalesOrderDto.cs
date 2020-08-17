using NetworkMarketing.BL.Dtos.ItemDtos;
using NetworkMarketing.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Dtos.SalesOrderDtos
{
    public class GetSalesOrderDto
    {
        public int Id { get; set; }
        public Distributor Distributor { get; set; }
        public int DistributorId { get; set; }
        public DateTime PostingDate { get; set; }
        public List<GetItemDto> Rows { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
