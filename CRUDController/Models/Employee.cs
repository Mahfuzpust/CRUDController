using System.ComponentModel.DataAnnotations;

namespace CRUDController.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="The name fields can't blank")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public decimal Salary { get; set; }

    }
}
