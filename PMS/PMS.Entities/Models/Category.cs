using System.ComponentModel.DataAnnotations;

namespace PMS.Entities.Models; 

public class Category {
    public Category() {
        Products = new HashSet<Product>();
    }
    [Key]
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string? IconUrl { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? RegisterDate { get; set; }
    public virtual IEnumerable<Product> Products { get; set; }
}