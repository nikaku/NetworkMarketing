using NetworkMarketing.BL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace NetworkMarketing.BL.Entities
{
    public class Distributor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
        public virtual IdentityInfo IdentityInfo { get; set; }
        public int IdentityInfoId { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public int ContactInfoId { get; set; }
        public virtual AddressInfo AddressInfo { get; set; }
        public int AddressInfoId { get; set; }
        public virtual IList<Distributor> Recomendators { get; set; }
        public virtual IList<SalesOrder> SalesOrders { get; set; }
        public int? RecomendatorId { get; set; }
        public int ReferalLevel { get; set; }



        public decimal CalculateBonus(decimal percent)
        {
            decimal result = 0;
            if (SalesOrders == null)
            {
                return 0;
            }
            result = SalesOrders.Sum(x => x.TotalPrice) * percent / 100;
            return result;
        }

        //public HashSet<TestChild> GetChildren()
        //{
        //    HashSet<TestChild> identities = new HashSet<TestChild>();
        //    {
        //        void chooseIds(ref HashSet<TestChild> ids, Distributor sect)
        //        {
        //            ids.Add(new TestChild { Id = sect.Id, Level = sect.ReferalLevel });
        //            if (sect.Recomendators != null)
        //                foreach (var item in sect.Recomendators)
        //                    chooseIds(ref ids, item);
        //        }
        //        chooseIds(ref identities, this);
        //    }
        //    return identities;
        //}

        //public class TestChild
        //{
        //    public int Id { get; set; }
        //    public int Level { get; set; }
        //}
    }
}
