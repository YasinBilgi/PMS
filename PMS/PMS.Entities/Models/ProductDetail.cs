namespace PMS.Entities.Models; 

public class ProductDetail {
    public int ProductDetailId { get; set; }
    public string Description { get; set; }
    public string? Features { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}