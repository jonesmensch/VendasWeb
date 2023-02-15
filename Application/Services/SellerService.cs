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

        public OperationResult<Seller> Create(Seller seller)
        {
            try
            {
                var result = _sellerRepository.Create(seller);
                if (result == null)
                    return OperationResult<Seller>.CreateFail("Seller not found.");

                return OperationResult<Seller>.CreateSuccess(seller);
            }
            catch
            {
                return OperationResult<Seller>.CreateFail("There was an unexpected error, please try again.");
            }
        }

        public OperationResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult.CreateFail("Id not found.");

                var result = _sellerRepository.GetById(id);
                if (result == null)
                    return OperationResult.CreateFail("Seller not found.");

                _sellerRepository.Delete(id);

                return OperationResult.CreateSuccess();
            }
            catch
            {
                return OperationResult.CreateFail("There was an unexpected error, please try again.");
            }
        }

        public List<Seller> FindAll()
        {
            return _sellerRepository.FindAll();
        }

        public OperationResult<SellerFormViewModel> GetById(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult<SellerFormViewModel>.CreateFail("Id not found");

                var obj = _sellerRepository.GetById(id);
                if (obj == null)
                    return OperationResult<SellerFormViewModel>.CreateFail("Seller not found");

                var departments = _departmentRepository.FindAll();
                var sellerForm = new SellerFormViewModel { Departments = departments, Seller = obj };

                return OperationResult<SellerFormViewModel>.CreateSuccess(sellerForm);
            }
            catch
            {
                return OperationResult<SellerFormViewModel>.CreateFail("There was an unexpected error, please try again");
            }
        }

        public OperationResult<Seller> Edit(Seller seller)
        {
            try
            {
                var result = _sellerRepository.Edit(seller);
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
