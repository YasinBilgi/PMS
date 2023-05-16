using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Entities.Models;

public class Store {
    [Key] 
    public int StoreId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    [Required] 
    public int ManagerId { get; set; }
    [ForeignKey("ManagerId")] 
    public virtual Manager Manager { get; set; }
}