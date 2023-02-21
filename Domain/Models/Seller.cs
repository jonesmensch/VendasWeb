using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public SalesRecord? SalesRecord { get; set; }
        public Department? Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}
