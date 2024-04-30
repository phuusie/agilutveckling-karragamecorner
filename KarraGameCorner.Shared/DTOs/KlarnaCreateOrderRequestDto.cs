using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Klarna;

public class KlarnaCreateOrderRequestDto
{
    public string purchase_country { get; set; }
    public string purchase_currency { get; set; }
    public string locale { get; set; }
    public decimal order_amount { get; set; }
    public decimal order_tax_amount { get; set; }
    public List<KlarnaOrderLinesDto> order_lines { get; set; }
    public KlarnaMerchantUrlsDto merchant_urls { get; set; }
    public KlarnaBillingAddressDto billing_address { get; set; }
}