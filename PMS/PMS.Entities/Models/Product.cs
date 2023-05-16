using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Entities.Models; 

public class Product {
    [Key]
    public int ProductId { get; set; }

    [Required]
    public int CategoryId { get; set; }
    
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? RegisterDate { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
    public virtual ProductDetail ProductDetail { get; set; }
}