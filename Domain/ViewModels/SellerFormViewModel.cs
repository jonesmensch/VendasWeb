using Domain.Models;

namespace Domain.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller? Seller { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}
