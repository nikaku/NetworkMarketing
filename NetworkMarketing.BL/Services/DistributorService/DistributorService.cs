using NetworkMarketing.BL.Dtos.DistributorDtos;
using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Filters;
using NetworkMarketing.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkMarketing.BL.Services.DistributorService
{
    public class DistributorService : IDistributorService
    {
        public Result CreateDistributor(Distributor distributor, int recomendatorReferalsCount, Distributor recomendator)
        {
            Result result = new Result();
            if (distributor.RecomendatorId == 0 || distributor.RecomendatorId == null)
            {
                distributor.ReferalLevel = 0;
            }
            else
            {
                int referalLevel = 0;
                if (recomendator == null)
                {
                    referalLevel = 0;
                    result.Mesasage = "Recomendator Does Not Exists";
                    result.IsSuccess = false;
                    return result;
                }
                else
                {
                    referalLevel = recomendator.ReferalLevel;
                }
                if (recomendatorReferalsCount > 2)
                {
                    result.Mesasage = "Recomendator Has More Then 3 Referals";
                    result.IsSuccess = false;
                    return result;
                }
                distributor.ReferalLevel = ++recomendator.ReferalLevel;
                if (referalLevel > 4)
                {
                    result.Mesasage = "Referal Depth reached Limit";
                    result.IsSuccess = false;
                    return result;
                }
            }
            result.IsSuccess = true;
            return result;
        }


        public decimal CalculateBonus(decimal percent, Distributor distributor)
        {
            decimal result = 0;
            if (distributor.SalesOrders == null)
            {
                return 0;
            }
            result = distributor.SalesOrders.Sum(x => x.TotalPrice) * percent / 100;
            return result;
        }

        public decimal CalculateCumulativeBonus(Distributor distributor, List<Distributor> childs, List<Distributor> grandChilds)
        {
            decimal result = CalculateBonus(10, distributor);
            foreach (var distributorChild in childs)
            {
                result += CalculateBonus(5, distributorChild);
                foreach (var grandChild in grandChilds)
                {
                    result += CalculateBonus(1, grandChild);
                }
            }
            return result;
        }

    }
}
