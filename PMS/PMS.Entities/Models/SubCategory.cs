using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Entities.Models; 

public class SubCategory {
    [Key]
    public int SubCategoryId { get; set; }
    public string Title { get; set; }
    public string? IconUrl { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? RegisterDate { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
}