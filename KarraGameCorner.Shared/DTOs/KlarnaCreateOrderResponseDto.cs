namespace KarraGameCorner.Shared.DTOs;

public class KlarnaCreateOrderResponseDto
{
    public string order_id { get; set; }
    public string status { get; set; }
    public string purchase_country { get; set; }
    public string purchase_currency { get; set; }
    public string locale { get; set; }
    public KlarnaBillingAddressDto billing_address { get; set; }
    public KlarnaCustomerDto customer { get; set; }
    public KlarnaBillingAddressDto shipping_address { get; set; }
    public decimal order_amount { get; set; }
    public decimal order_tax_amount { get; set; }
    public List<KlarnaOrderLinesDto> order_lines { get; set; }
    public KlarnaMerchantUrlsDto merchant_urls { get; set; }
    public string html_snippet { get; set; }
    public string started_at { get; set; }
    public string completed_at { get; set; }
    public string last_modified_at { get; set; }
    public KlarnaOptionsDto options { get; set; }
    public List<object> external_payment_methods { get; set; } 
    public List<object> external_checkouts { get; set; } 
}