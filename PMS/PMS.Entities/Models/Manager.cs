using System.ComponentModel.DataAnnotations;

namespace PMS.Entities.Models; 

public class Manager {
    public Manager() {
        Stores = new HashSet<Store>();
    }
    [Key]
    public int ManagerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public virtual IEnumerable<Store> Stores { get; set; }
}