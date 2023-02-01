namespace Domain.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public SalesRecord? SalesRecord { get; set; }
        public Department? Department { get; set; }
    }
}
