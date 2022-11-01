using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmailClientApp.Data
{
    public class EmailModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Firts Name")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
