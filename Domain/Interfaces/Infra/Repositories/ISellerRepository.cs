using Domain.Models;

namespace Domain.Interfaces.Infra.Repositories
{
    public interface ISellerRepository
    {
        public Task<List<Seller>> FindAllAsync();
        public Task<Seller> GetByIdAsync(int id);
        public Task<OperationResult<Seller>> CreateAsync(Seller seller);
        public Task<OperationResult<Seller>> EditAsync(Seller seller);
        public Task<OperationResult> DeleteAsync(int id);
    }
}
