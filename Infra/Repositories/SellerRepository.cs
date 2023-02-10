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

        public Seller Create(Seller seller)
        {
            _context.sellers.Add(seller);
            _context.SaveChanges();

            return seller;
        }

        public Seller Update(Seller seller)
        {
            var sellers = GetById(seller.Id);

            if (sellers == null)
                throw new System.Exception("There was an error while trying to update!");

            sellers.Name = seller.Name;
            sellers.BirthDate = seller.BirthDate;
            sellers.Email= seller.Email;
            sellers.BaseSalary = seller.BaseSalary;
            sellers.Department = seller.Department;
            
            _context.Update(sellers);
            _context.SaveChanges();

            return sellers;
        }

        public OperationResult Delete(int id)
        {
            try
            {
                var seller = GetById(id);

                if (seller == null)
                    return OperationResult.CreateFail("An error has occurred, please try again!");

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
