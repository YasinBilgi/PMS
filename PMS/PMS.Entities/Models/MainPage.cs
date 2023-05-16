using System.ComponentModel.DataAnnotations;

namespace PMS.Entities.Models; 

public class MainPage {
    [Key]
    public int MainPageId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public string Notice { get; set; }
}