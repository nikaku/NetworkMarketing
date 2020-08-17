using NetworkMarketing.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace NetworkMarketing.BL.Entities
{
    public class AddressInfo
    {
        public int Id { get; set; }
        public AddressType addressType { get; set; }
        public string Address { get; set; }
    }
}
