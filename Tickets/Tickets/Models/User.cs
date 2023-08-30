using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.Models
{
    public class User
    {
            
        
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "Max Lenght is 20 Char")]
        public string fName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "Max Lenght is 20 Char")]
        public string lName { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        //[RegularExpression("^(?=.*[A - Za - z])(?=.*\\d)[A - Za - z\\d]{8,}$",
        //  ErrorMessage = "password must be eight characters, at least one letter and one number")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password ", ErrorMessage = "Password does not match ")]
        public string ConfirmPassword { get; set; }

        //public List<Order> Orders { get; set; }

        //public List<OrderItem> OrderItems { get; set; }


    }
}
