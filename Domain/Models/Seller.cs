using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string? Email { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public SalesRecord? SalesRecord { get; set; }
        public Department? Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}
