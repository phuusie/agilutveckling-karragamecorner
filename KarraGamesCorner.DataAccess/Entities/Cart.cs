namespace KarraGameCorner.DataAccess.Entities;

public class Cart
{
    public int Id { get; set; }
    public List<CartItem> Products { get; set; }
}