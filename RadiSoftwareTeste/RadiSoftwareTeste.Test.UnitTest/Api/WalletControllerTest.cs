using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RadiSoftwareTeste.Application.Wallet.Controllers;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.DTO;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Test.UnitTest.Api
{
    public class WalletControllerTest
    {
        private readonly Mock<IWalletService> _walletService;
        private readonly Mock<ICardService> _cardService;
        private readonly Mock<ITokenService> _tokenService;
        private readonly Fixture _fixture;
        private readonly WalletController _controller;

        public WalletControllerTest()
        {
            _walletService = new Mock<IWalletService>();
            _cardService = new Mock<ICardService>();
            _tokenService = new Mock<ITokenService>();
            _fixture = new Fixture();
            _controller = new WalletController
                (
                    _walletService.Object,
                    _cardService.Object,
                    _tokenService.Object
                );
        }

        [Test]
        public void InsertWalletOK()
        {
            var createWalletRequest = _fixture.Create<CreateWalletRequest>();
            var newWallet = _fixture.Create<WalletDTO>();

            _walletService
                .Setup(x => x.CreateWallet(It.IsAny<Guid>()))
                .Returns(newWallet);

            var result = _controller.InsertWallet(createWalletRequest);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

        }

        [Test]
        public void InsertWalletReturnNull()
        {
            var createWalletRequest = _fixture.Create<CreateWalletRequest>();

            _walletService
                .Setup(x => x.CreateWallet(It.IsAny<Guid>()))
                .Returns((WalletDTO) null);

            var result = _controller.InsertWallet(createWalletRequest);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
        }

        [Test]
        public void InsertWalleReceiveNullArgument()
        {
            var createWalletRequest = (CreateWalletRequest) null;

            var result = _controller.InsertWallet(createWalletRequest);
            var badRequestResult = result as BadRequestObjectResult;

            Assert.NotNull(badRequestResult);
            Assert.AreEqual(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public void GetWalletByCustomerIdOK()
        {
            var newWallet = _fixture.Create<WalletDTO>();

            _walletService
                .Setup(x => x.GetWalletdBy(It.IsAny<Guid>()))
                .Returns(newWallet);

            var result = _controller.GetWalletByCustomerId(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

        }
    }
}
