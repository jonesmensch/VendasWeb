using Domain.Enums;

namespace Domain.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public SaleStatus SaleStatus { get; set; }
    }
}
