using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} required")]
        public string? Name { get; set; }
    }
}
