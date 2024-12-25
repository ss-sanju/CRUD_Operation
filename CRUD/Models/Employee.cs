using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }  
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        public string? Email { get; set; }
         
    }
}
