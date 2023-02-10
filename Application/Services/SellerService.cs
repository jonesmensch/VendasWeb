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

        public bool Delete(int id)
        {
            return _sellerRepository.Delete(id);
        }

        public List<Seller> FindAll()
        {
            return _sellerRepository.FindAll();
        }

        public Seller Update(Seller seller)
        {
            return _sellerRepository.Update(seller);
        }
    }
}
