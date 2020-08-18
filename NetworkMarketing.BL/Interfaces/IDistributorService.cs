using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL.Interfaces
{
    public interface IDistributorService
    {
        Result CreateDistributor(Distributor distributor, int recomendatorReferalsCount, Distributor recomendator);
        public decimal CalculateBonus(decimal percent, Distributor distributor);

        public decimal CalculateCumulativeBonus(Distributor distributor, List<Distributor> childs, List<Distributor> grandChilds);

    }
}
