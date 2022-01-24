using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RadiSoftwareTeste.Application.Customer.Controllers;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.Entities;
using System;

namespace RadiSoftwareTeste.Test.UnitTest.Api
{
    public class CustomerControllerTest
    {
        private readonly Mock<ICustomerService> _customerService;
        private readonly Fixture _fixture;
        private readonly CustomerController _controller;

        public CustomerControllerTest()
        {
            _customerService = new Mock<ICustomerService>();
            _fixture = new Fixture();
            _controller = new CustomerController( _customerService.Object);
        }


        public void GetCustomerByIdOK()
        {
            var customer = _fixture.Create<Customer>();

            _customerService
                .Setup(x => x.GetCustomerBy(It.IsAny<Guid>()))
                .Returns(customer);

            var result = _controller.GetCustomerById(customer.CustomerId);

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Test]
        public void GetCustomerByIdReturnsNull()
        {

            _customerService
                .Setup(x => x.GetCustomerBy(It.IsAny<Guid>()))
                .Returns((Customer) null);

            var result = _controller.GetCustomerById(It.IsAny<Guid>());

            var okResult = result as OkObjectResult;

            Assert.Null(okResult);
        }

    }
}
