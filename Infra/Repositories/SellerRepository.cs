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
    }
}
