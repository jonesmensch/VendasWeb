using Domain.Interfaces.Application.Services;
using Domain.Interfaces.Infra.Repositories;
using Domain.Models;

namespace Application.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public Seller Create(Seller seller)
        {
            return _sellerRepository.Create(seller);
        }

        public List<Seller> FindAll()
        {
            return _sellerRepository.FindAll();
        }
    }
}
