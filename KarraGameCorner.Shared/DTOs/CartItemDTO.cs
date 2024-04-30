namespace KarraGameCorner.Shared.DTOs;

public class CartItemDTO
{
    public int Id { get; set; }
    public ProductDTO Product { get; set; }
    public int Quantity { get; set; }
}