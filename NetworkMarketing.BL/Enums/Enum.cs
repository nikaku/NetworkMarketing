using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Enums
{
    public enum Gender
    {
        Male = 0,
        FeMale = 1,
    };
    public enum IdentityType
    {
        IdCard = 0,
        Passport = 1,
    };
    public enum ContactType
    {
        Mobile = 0,
        Telephone = 1,
        Email = 2,
        Fax = 3,
    };
    public enum AddressType
    {
        ActualAddress = 0,
        RegistrationAddress = 1,
    };
}
