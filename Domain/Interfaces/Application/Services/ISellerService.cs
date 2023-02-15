using Domain.Models;
using Domain.ViewModels;

namespace Domain.Interfaces.Application.Services
{
    public interface ISellerService
    {
        public List<Seller> FindAll();
        public OperationResult<Seller> Create(Seller seller);
        public OperationResult<Seller> Edit(Seller seller);
        public OperationResult Delete(int id);
        public OperationResult<SellerFormViewModel> GetById(int id);
    }
}
