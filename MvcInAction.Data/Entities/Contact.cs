using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcInAction.Data.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}