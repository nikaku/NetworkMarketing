using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Interfaces;
using NetworkMarketing.BL.Services.DistributorService;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace NetworkMarketing.Tests
{
    public class DistributorServiceTests
    {
        IDistributorService distributorService;
        Distributor distributor;

        public DistributorServiceTests()
        {
            distributorService = new DistributorService();
        }

        [Fact]
        public void CreateDistributorTest_ReferalsMoreThenThree_ReturnsFalse()
        {
            int reccomendatorsCount = 4;
            var res = distributorService.CreateDistributor(new Distributor { RecomendatorId = 1 }, reccomendatorsCount, new Distributor());
            Assert.False(res.IsSuccess);
        }

        [Fact]
        public void CreateDistributorTest_ReferalsLessThenThree_ReturnsTrue()
        {
            int reccomendatorsCount = 2;
            var res = distributorService.CreateDistributor(new Distributor { RecomendatorId = 1 }, reccomendatorsCount, new Distributor());
            Assert.True(res.IsSuccess);
        }
        [Fact]
        public void CreateDistributorTest_ReferalsDeptMoreThenFive_ReturnsFalse()
        {
            int reccomendatorsCount = 5;
            var res = distributorService.CreateDistributor(new Distributor { RecomendatorId = 1 }, reccomendatorsCount, new Distributor { ReferalLevel = 1 });
            Assert.False(res.IsSuccess);
        }

        [Fact]
        public void CreateDistributorTest_ReferalsDeptLessThenFive_ReturnsTrue()
        {
            int reccomendatorsCount = 2;
            var res = distributorService.CreateDistributor(new Distributor { RecomendatorId = 1 }, reccomendatorsCount, new Distributor { ReferalLevel = 4 });
            Assert.True(res.IsSuccess);
        }

        [Fact]
        public void CalculateBonus_HaveNoSales_ReturnsZero()
        {
            distributor = new Distributor();
            decimal percent = 12.4m;
            var res = distributorService.CalculateBonus(percent, distributor);
            Assert.Equal(0, res);
        }

        [Fact]
        public void CalculateBonus_HaveSales_ReturnsPercentOfsales()
        {
            distributor = new Distributor();
            var so1 = new SalesOrder { TotalPrice = 100 };
            var so2 = new SalesOrder { TotalPrice = 200 };
            distributor.SalesOrders.Add(so1);
            distributor.SalesOrders.Add(so2);
            decimal percent = 10;
            var res = distributorService.CalculateBonus(percent, distributor);
            Assert.Equal(30, res);
        }

        [Fact]
        public void CalculateCumulativeBonus_HaveSales_ReturnsPercentOfsales()
        {
            var fakeDistributorService = new Mock<IDistributorService>();

            //Arrange
            distributor = new Distributor();
            var child1 = new Distributor();
            var grandChild1 = new Distributor();
            List<Distributor> childs = new List<Distributor>();
            childs.Add(child1);
            List<Distributor> granchChilds = new List<Distributor>();
            granchChilds.Add(grandChild1);
            var so1 = new SalesOrder { TotalPrice = 100 };
            var so2 = new SalesOrder { TotalPrice = 200 };

            foreach (var child in childs)
            {
                child.SalesOrders.Add(so1);
                child.SalesOrders.Add(so2);
            }

            foreach (var grandChild in granchChilds)
            {
                grandChild.SalesOrders.Add(so1);
                grandChild.SalesOrders.Add(so2);
            }


            distributor.SalesOrders.Add(so1);
            distributor.SalesOrders.Add(so2);

            //Act
            var res = distributorService.CalculateCumulativeBonus(distributor, childs, granchChilds);

            //Assert
            Assert.Equal(48, res);
        }

    }
}
