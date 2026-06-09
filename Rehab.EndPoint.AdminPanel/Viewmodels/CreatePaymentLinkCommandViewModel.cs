namespace Rehab.EndPoint.AdminPanel.Viewmodels
{
    public class CreatePaymentLinkCommandViewModel
    {
        public int RequestId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
