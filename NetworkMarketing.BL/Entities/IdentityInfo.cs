using NetworkMarketing.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace NetworkMarketing.BL.Entities
{
    public class IdentityInfo
    {
        public int Id { get; set; }
        public IdentityType IdentityType { get; set; }
        public string Serie { get; set; }
        public int Number { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int PersonalId { get; set; }
        public string Issuer { get; set; }
    }
}
