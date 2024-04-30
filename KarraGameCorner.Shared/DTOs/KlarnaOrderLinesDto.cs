namespace KarraGameCorner.Shared.DTOs;

public class KlarnaOrderLinesDto
{
    public string name { get; set; }
    public decimal quantity { get; set; }
    public decimal unit_price { get; set; }
    public decimal tax_rate { get; set; }
    public decimal total_amount { get; set; }
    public decimal total_tax_amount { get; set; }
}