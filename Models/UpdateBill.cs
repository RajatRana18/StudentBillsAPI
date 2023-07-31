namespace StudentBillsAPI.Models
{
    public class UpdateBill
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long Bill { get; set; }
    }
}
