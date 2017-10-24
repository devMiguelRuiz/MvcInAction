using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcInAction.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [MaxLength(200)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}