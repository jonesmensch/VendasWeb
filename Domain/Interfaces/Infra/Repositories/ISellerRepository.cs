using Domain.Models;

namespace Domain.Interfaces.Infra.Repositories
{
    public interface ISellerRepository
    {
        public List<Seller> FindAll();
        public Seller GetById(int id);
        public Seller Create(Seller seller);
    }
}
