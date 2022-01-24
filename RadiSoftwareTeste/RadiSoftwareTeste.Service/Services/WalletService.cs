using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.DTO;
using RadiSoftwareTeste.Domain.Models.DTO.Response;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Utils;
using RadiSoftwareTeste.Infra.Facade.Interfaces;
using System;
using System.Linq;

namespace RadiSoftwareTeste.Service.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _repository;
        private readonly ICustomerFacade _customerFacade;

        public WalletService(IWalletRepository repository,
                             ICustomerFacade customerFacade)
        {
            _repository = repository;
            _customerFacade = customerFacade;
        }

        public WalletDTO CreateWallet(Guid CustomerId)
        {
            var newId = BaseUtils.NextIdList(_repository.GetAllWallets());


            var customer = _customerFacade.GetCustomerBy(CustomerId);
            if (customer == null) throw new Exception("Customer does not exist.");

            var newWallet = _repository.CreateWallet(new Wallet()
            {
                Id = newId,
                WalletId = Guid.NewGuid(),
                Customer = customer,
                RegistrationDate = DateTime.UtcNow,
                Status = true
            });

            return GetWalletDTO(newWallet);



        }

        public WalletDTO GetWalletdBy(Guid customerId)
        {
            var wallet = _repository.GetWalletdBy(customerId);
            if (wallet == null) throw new Exception("Wallet does not exist.");

            return GetWalletDTO(wallet);
        }

        public WalletDTO GetWalletdByWalletId(Guid walletId)
        {
            var wallet = _repository.GetWalletdByWalletId(walletId);
            if (wallet == null) throw new Exception("Wallet does not exist.");

            return GetWalletDTO(wallet);
        }

        public CreateCardResponse InsertCard(Guid walletId, Card card, Guid TokenId, string tokenValue)
        {
            var wallet = _repository.GetWalletdByWalletId(walletId);
            if (wallet == null) throw new Exception("Wallet does not exist.");

            _repository.InsertCardWallet(wallet, card);

            return new CreateCardResponse()
            {
                CardId = card.CardId,
                RegistrationDate = card.RegistrationDate,
                TokenId = TokenId,
                Token = tokenValue,
                WalletId = wallet.WalletId
            };

        }

        private WalletDTO GetWalletDTO(Wallet wallet)
        {
            var result = new WalletDTO()
            {
                Id = wallet.Id,
                WalletId = wallet.WalletId,
                RegistrationDate = wallet.RegistrationDate,
                Status = wallet.Status
            };

            if (wallet.Cards != null)
            {
                result.Cards = wallet.Cards.Select(x => new CardDTO()
                {
                    CardId = x.CardId,
                    Description = x.Description,
                    RegistrationDate = x.RegistrationDate,
                    Status = x.Status
                }).ToList();
            }

            return result;
        }

    }
}
