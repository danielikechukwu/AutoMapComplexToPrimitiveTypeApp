using System.ComponentModel.DataAnnotations;

namespace AutoMapComplexToPrimitiveType.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required] 
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public int UserId { get; set; } //Foreign key.

        public User User { get; set; }

    }
}
