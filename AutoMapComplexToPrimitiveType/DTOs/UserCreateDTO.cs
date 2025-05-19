using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace AutoMapComplexToPrimitiveType.DTOs
{
    public class UserCreateDTO
    {
        // DTO for creating a new User. The address details are provided as primitive types.
        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        // These are primitive properties that will be mapped into a complex Address object.
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

    }
}
