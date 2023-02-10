using Domain.Models;

namespace Domain.Interfaces.Application.Services
{
    public interface ISellerService
    {
        public List<Seller> FindAll();
        public Seller Create(Seller seller);
        public Seller Update(Seller seller);
        public bool Delete(int id);
    }
}
