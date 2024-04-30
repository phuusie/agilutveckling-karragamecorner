namespace KarraGameCorner.DataAccess.Entities;

public class WishList
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public bool Status { get; set; }
}