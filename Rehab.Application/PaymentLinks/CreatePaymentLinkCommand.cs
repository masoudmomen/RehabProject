namespace Rehab.Application.PaymentLinks
{
    public class CreatePaymentLinkCommand
    {
        public int RequestId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string SuccessUrl { get; set; } = string.Empty;
        public string CancelUrl { get; set; } = string.Empty;
    }
}
