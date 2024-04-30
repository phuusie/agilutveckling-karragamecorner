using System.ComponentModel.DataAnnotations;

namespace KarraGameCorner.DataAccess.Entities;

public class Order
{
    public int Id { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public List<OrderItem> Products { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShippingAddress { get; set; }
    public double TotalPrice { get; set; }

}