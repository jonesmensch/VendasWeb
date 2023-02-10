using Domain;
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

        public OperationResult<Seller> Create(Seller seller)
        {
            return _sellerRepository.Create(seller);
        }

        public OperationResult Delete(int id)
        {
            return _sellerRepository.Delete(id);
        }

        public List<Seller> FindAll()
        {
            return _sellerRepository.FindAll();
        }

        public Seller GetById(int id)
        {
            return _sellerRepository.GetById(id);
        }

        public OperationResult<Seller> Edit(Seller seller)
        {
            return _sellerRepository.Edit(seller);
        }
    }
}
