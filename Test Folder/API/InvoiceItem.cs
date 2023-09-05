namespace Invoice // Replace with your actual namespace
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public int InvoiceCurrencyId { get; set; } // Assuming CurrencyId is used here
        public int VendorId { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime InvoiceReceivedDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public bool IsActive { get; set; }
    }
}
