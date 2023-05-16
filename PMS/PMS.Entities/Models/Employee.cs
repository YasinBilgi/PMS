using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Entities.Models; 

public class Employee {
    [Key]
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    [Required]
    public int StoreId { get; set; }
    [ForeignKey("StoreId")]
    public virtual Store Store { get; set; }
}