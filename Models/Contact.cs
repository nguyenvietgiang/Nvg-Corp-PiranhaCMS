
namespace Nvg_Corp.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
