using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using KarraGameCorner.DataAccess.Enums;

namespace KarraGameCorner.DataAccess.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; }
    public List<ProductCategory> Categories { get; set; }
    public EntertainmentSoftwareRatingBoard ESRB { get; set; }
    public string Picture { get; set; }
    public int Quantity { get; set; }
    public bool Status { get; set; }

    
}