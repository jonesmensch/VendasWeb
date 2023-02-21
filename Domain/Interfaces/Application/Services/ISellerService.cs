using Domain.Models;
using Domain.ViewModels;

namespace Domain.Interfaces.Application.Services
{
    public interface ISellerService
    {
        public Task<List<Seller>> FindAllAsync();
        public Task<OperationResult<Seller>> CreateAsync(Seller seller);
        public Task<OperationResult<Seller>> EditAsync(Seller seller);
        public Task<OperationResult> DeleteAsync(int id);
        public Task<OperationResult<SellerFormViewModel>> GetByIdAsync(int id);
    }
}
