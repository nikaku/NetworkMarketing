using NetworkMarketing.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace NetworkMarketing.BL.Entities
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Contact { get; set; }
    }
}
