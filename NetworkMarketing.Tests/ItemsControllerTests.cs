using Xunit;
using Moq;
using NetworkMarketing.Controllers;
using NetworkMarketing.BL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NetworkMarketing.Tests
{
    public class ItemsControllerTests
    {
        [Fact]
        public void ItemsControllerTests_GetItemWithZeroId_ReturnsNull()
        {
            var fakeIItemRepository = new Mock<IItemRepository>();
            var fakiunitOWork = new Mock<IUnitOfWork>();
            fakiunitOWork.Setup(x => x.ItemRepository).Returns(fakeIItemRepository.Object);
            var mapper = new Mock<IMapper>();

            ItemsController itemsController = new ItemsController(fakiunitOWork.Object, mapper.Object);

            var res = itemsController.Get(0);

            var notFoundresult = res as NotFoundResult;

            // assert
            Assert.NotNull(notFoundresult);
            Assert.Equal(404, notFoundresult.StatusCode);


        }

        [Fact]
        public void ItemsControllerTests_GetItemWithId_ReturnsItem()
        {
            var fakeIItemRepository = new Mock<IItemRepository>();
            var fakiunitOWork = new Mock<IUnitOfWork>();
            fakiunitOWork.Setup(x => x.ItemRepository).Returns(fakeIItemRepository.Object);
            fakeIItemRepository.Setup(x => x.Get(0)).Returns(new BL.Entities.Item());

            var mapper = new Mock<IMapper>();

            ItemsController itemsController = new ItemsController(fakiunitOWork.Object, mapper.Object);

            var res = itemsController.Get(0);

            var okResult = res as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);


        }



    }
}
