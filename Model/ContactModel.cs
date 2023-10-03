using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact_Manager.Model
{
    public class ContactModel
    {
        public ContactModel()
        {
            CreationDateTimestamp = DateTime.UtcNow;
        }

        [Required]
        [MinLength(3, ErrorMessage = "The Salutaion must be atleast 2 characters long.")]
        public string Salutation { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The FirstName must be atleast 2 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The LastName must be atleast 2 characters long.")]
        public string LastName { get; set; }
        private string _displayname;
        public string DisplayName
        {
            get
            {
                return _displayname ?? $"{Salutation} {FirstName} {LastName}";
            }
            set
            {
                _displayname = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }

        public DateTime? Birthdate { get; set; }

     
        public DateTime CreationDateTimestamp { get; set; }

        public bool NotifyHasBirthdaySoon
        {
            get
            {
                DateTime currentDate = DateTime.Now;
                DateTime? birthdate = Birthdate;

                if (!birthdate.HasValue)
                {
                    return false; // Birthdate is not set
                }

                DateTime dateIn14Days = currentDate.AddDays(14);

                // Check if the birthday is within the next 14 days, considering the year
                if ((birthdate.Value.Month == currentDate.Month && birthdate.Value.Day >= currentDate.Day && birthdate.Value.Day <= dateIn14Days.Day) ||
                    (birthdate.Value.Month == dateIn14Days.Month && birthdate.Value.Day >= dateIn14Days.Day))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string? PhoneNumber { get; set; }
    }
}
