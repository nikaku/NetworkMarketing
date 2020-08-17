using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace NetworkMarketing.BL.Dtos.DistributorDtos
{
    public class GetDistributorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
        public IdentityInfo IdentityInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public AddressInfo AddressInfo { get; set; }
        public Distributor Recomenator { get; set; }
    }
}
