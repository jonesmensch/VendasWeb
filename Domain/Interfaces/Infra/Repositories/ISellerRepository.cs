using Domain.Models;

namespace Domain.Interfaces.Infra.Repositories
{
    public interface ISellerRepository
    {
        public List<Seller> FindAll();
        public Seller GetById(int id);
        public OperationResult<Seller> Create(Seller seller);
        public OperationResult<Seller> Edit(Seller seller);
        public OperationResult Delete(int id);
    }
}
