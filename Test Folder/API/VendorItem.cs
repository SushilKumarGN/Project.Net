namespace Vendor // Replace with your actual namespace
{
    public class VendorItem
    {
        public int VendorID { get; set; }
        public string VendorLongName { get; set; }
        public string VendorCode { get; set; }
        public string VendorPhoneNumber { get; set; }
        public string VendorEmail { get; set; }
        public DateTime VendorCreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
