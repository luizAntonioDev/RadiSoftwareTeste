using Microsoft.AspNetCore.Mvc;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Models;
using System;
using System.Linq;

namespace RadiSoftwareTeste.Application.Wallet.Controllers
{
    [Route("api/wallet")]
    [ApiController]
    public class WalletController : ApiBaseController
    {
        private readonly IWalletService _walletService;
        private readonly ICardService _cardService;
        private readonly ITokenService _tokenService;

        public WalletController(
            IWalletService walletService,
            ICardService cardService,
            ITokenService tokenService)
        {
            _walletService = walletService;
            _cardService = cardService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult InsertWallet(CreateWalletRequest request)
        {
            try
            {
                var newWallet = _walletService.CreateWallet(request.CustomerId);
                return Ok(BaseResponse(newWallet, true));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, $"Error on create digital wallet"));
            }
        }

        [HttpGet]
        [Route("{customerId}")]
        public IActionResult GetWalletByCustomerId(Guid customerId)
        {
            try
            {
                var wallet = _walletService.GetWalletdBy(customerId);
                return Ok(BaseResponse(wallet, true));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, $"Error while trying to get user {customerId} digital wallet."));
            }
        }

        [HttpPost]
        [Route("card")]
        public IActionResult InsertCardWallet(CreateCardRequest request)
        {
            try
            {
                var card = _cardService.InsertCard(request);
                var token = _tokenService.CreateToken(card,
                                                      _cardService.GetCardLast4Digits(card),
                                                      _cardService.GetCVVLength(card));

                var result = _walletService.InsertCard(request.WalletId, card, token.TokenId, token.Value);

                return Ok(BaseResponse(result, true));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, $"Error on adding card into digital wallet {request.WalletId}."));
            }
        }

        [HttpPost]
        [Route("token/validate")]
        public IActionResult ValidateCardToken(ValidateTokenRequest request)
        {
            try
            {

                var wallet = _walletService.GetWalletdByWalletId(request.WalletId);
                var cardWallet = wallet.Cards.Where(x => x.CardId == request.CardId).FirstOrDefault();

                if (cardWallet == null)
                {
                    return BadRequest(BaseResponse("Error", false, $"Invalid card for wallet {request.WalletId}."));
                }

                if (!_cardService.ValidateCVV(cardWallet.CardId, request.CVV))
                {
                    return BadRequest(BaseResponse("Error", false, $"Invalid CVV"));
                }

                var card = _cardService.GetCardBy(cardWallet.CardId);

                _tokenService.ValidateToken(request.TokenId, _cardService.GetCardLast4Digits(card), request.CVV.Length, request.Token);

                return Ok(BaseResponse("Valid", true));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, $"Error while validating card {request.CardId} token.}"));
            }
        }
    }
}
