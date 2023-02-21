using Domain;
using Domain.Interfaces.Application.Services;
using Domain.Interfaces.Infra.Repositories;
using Domain.Models;
using Domain.ViewModels;

namespace Application.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public SellerService(ISellerRepository sellerRepository, IDepartmentRepository departmentRepository)
        {
            _sellerRepository = sellerRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<OperationResult<Seller>> CreateAsync(Seller seller)
        {
            try
            {
                var result = await _sellerRepository.CreateAsync(seller);
                if (!result.Success)
                    return OperationResult<Seller>.CreateFail(result.Message);

                return OperationResult<Seller>.CreateSuccess(seller);
            }
            catch
            {
                return OperationResult<Seller>.CreateFail("There was an unexpected error, please try again.");
            }
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult.CreateFail("Id not found.");

                var result = await _sellerRepository.GetByIdAsync(id);
                if (result == null)
                    return OperationResult.CreateFail("Seller not found.");

                await _sellerRepository.DeleteAsync(id);

                return OperationResult.CreateSuccess();
            }
            catch
            {
                return OperationResult.CreateFail("There was an unexpected error, please try again.");
            }
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            try
            {
                return await _sellerRepository.FindAllAsync();
            }
            catch
            {
                return new List<Seller>();
            }
        }

        public async Task<OperationResult<SellerFormViewModel>> GetByIdAsync(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult<SellerFormViewModel>.CreateFail("Id not found");

                var obj = await _sellerRepository.GetByIdAsync(id);
                if (obj == null)
                    return OperationResult<SellerFormViewModel>.CreateFail("Seller not found");

                var departments = await _departmentRepository.FindAllAsync();
                var sellerForm = new SellerFormViewModel { Departments = departments, Seller = obj };

                return OperationResult<SellerFormViewModel>.CreateSuccess(sellerForm);
            }
            catch
            {
                return OperationResult<SellerFormViewModel>.CreateFail("There was an unexpected error, please try again");
            }
        }

        public async Task<OperationResult<Seller>> EditAsync(Seller seller)
        {
            try
            {
                var result = await _sellerRepository.EditAsync(seller);
                if (result == null)
                    return OperationResult<Seller>.CreateFail("Seller not found");

                return OperationResult<Seller>.CreateSuccess(seller);
            }
            catch
            {
                return OperationResult<Seller>.CreateFail("There was an unexpected error, please try again");
            }
        } 
    }
}
