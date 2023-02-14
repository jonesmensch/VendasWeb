using Domain;
using Domain.Interfaces.Infra.Repositories;
using Domain.Models;
using VendasWeb.Data;

namespace Infra.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly Context _context;

        public SellerRepository(Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.sellers.ToList();
        }

        public Seller GetById(int id)
        {
            return _context.sellers.FirstOrDefault(x => x.Id == id);
        }

        public OperationResult<Seller> Create(Seller seller)
        {
            try
            {
                _context.sellers.Add(seller);
                _context.SaveChanges();

                return OperationResult<Seller>.CreateSuccess(seller);
            }
            catch
            {
                return OperationResult<Seller>.CreateFail(seller, "An error has occurred, please try again.");
            }
        }

        public OperationResult<Seller> Edit(Seller seller)
        {

            if (!_context.sellers.Any(x => x.Id == seller.Id))
                return OperationResult<Seller>.CreateFail(seller, "Id not found.");

            try
            {
                _context.Update(seller);
                _context.SaveChanges();

                return OperationResult<Seller>.CreateSuccess(seller);
            }
            catch
            {
                return OperationResult<Seller>.CreateFail(seller, "There was an error while trying to update!");
            }
        }

        public OperationResult Delete(int id)
        {
            Seller seller = GetById(id);

            if (seller == null)
                return OperationResult.CreateFail("Id not found");

            try
            {
                _context.Remove(seller);
                _context.SaveChanges();

                return OperationResult.CreateSuccess();
            }
            catch
            {
                return OperationResult.CreateFail("An error has occurred, please try again!");
            }
        }
    }
}
