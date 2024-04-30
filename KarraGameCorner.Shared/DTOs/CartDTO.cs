namespace KarraGameCorner.Shared.DTOs;

public class CartDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItemDTO> Items { get; set; } = new();
}