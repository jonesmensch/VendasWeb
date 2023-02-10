using Domain.Models;

namespace Domain.Interfaces.Infra.Repositories
{
    public interface ISellerRepository
    {
        public List<Seller> FindAll();
        public Seller GetById(int id);
        public Seller Create(Seller seller);
        public Seller Update(Seller seller);
        public bool Delete(int id);
    }
}
