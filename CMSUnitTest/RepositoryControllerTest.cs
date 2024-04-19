﻿using CMS_Model.DTO;
using CMS_Repository;
using Moq;
using CourseManagementService.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CMSUnitTest
{
    [TestFixture]
    public class RepositoryControllerTest
    {
        [Test]
        public async Task GetSubscription_Returns_OkResult_With_SubscriptionDto()
        {

            var input = new SubscriptionDtoSearchInput
            {
                PageNumber = 1,
                PageSize = 1,
                Email = "ahuja_veda@huels.example",
                Gender = "male",
                UserName = "Veda Ahuja",
            };
            var listResult = new List<SubscriptionDto>();
            var result = new SubscriptionDto
            {
                Company = "Company1",
                Email = "ahuja_veda@huels.example",
                Gender = "male",
                Status = "active",
                UserId = "6859652",
                UserName = "Veda Ahuja",
                TrainingObj = new TrainingDto()
            };
            listResult.Add(result);

            // Arrange

            var sampleServiceMock = new Mock<ISubscriptionRepository>();
            sampleServiceMock.Setup(service => service.GetAllSubscriptionsDetailsAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(listResult));

            var controller = new SubscriptionController(sampleServiceMock.Object);

            // Act
            var resultfinal = await controller.GetAllSubscriptionsDetails(input) as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(resultfinal);
            Assert.IsInstanceOf<List<SubscriptionDto>>(resultfinal.Value);
            var okResult = (List<SubscriptionDto>)resultfinal.Value;
            Assert.AreEqual(listResult[0].UserName, okResult[0].UserName);
            Assert.AreEqual(listResult[0].Email, okResult[0].Email);
            Assert.AreEqual(listResult[0].Gender, okResult[0].Gender);
        }

        
    }
}
