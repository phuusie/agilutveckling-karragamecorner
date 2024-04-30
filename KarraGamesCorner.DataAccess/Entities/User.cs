using System.ComponentModel.DataAnnotations;

namespace KarraGameCorner.DataAccess.Entities;

public class User
{ 
    public int Id { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Alias { get; set; }
    public string Address { get; set; }
    public List<WishList>? WishLists { get; set; }
    public List<Review>? Reviews { get; set; }
    public Cart? Cart { get; set; }
    public bool IsAdmin { get; set; }
}