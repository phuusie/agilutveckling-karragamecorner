namespace KarraGameCorner.DataAccess.Entities;

public class Review
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public DateTime ReviewDate { get; set; }
}