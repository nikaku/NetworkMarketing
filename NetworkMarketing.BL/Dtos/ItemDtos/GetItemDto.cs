using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Dtos.ItemDtos
{
    public class GetItemDto
    {
        public int Id { get; set; }
        public string Desription { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
