using NetworkMarketing.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace NetworkMarketing.BL.Dtos.DistributorDtos
{
    public class CreateDistributorDto
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
        public int IdentityInfoId { get; set; }
        public int ContactInfoId { get; set; }
        public int AddressInfoId { get; set; }
        public int RecomendatorId { get; set; }
    }
}
