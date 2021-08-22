
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ManagementModels
{
    public class Customer
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string ConfirmPassword { get; set; }


        //Navigation Properties
        public ICollection<Store> userStores { get; set; }
    }

}