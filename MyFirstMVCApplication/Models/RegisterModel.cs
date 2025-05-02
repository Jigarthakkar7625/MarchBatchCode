using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMVCApplication.Models
{
    public class RegisterModel
    {
        public int UserId { get; set; } = 10;

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required !")]
        [MinLength(5, ErrorMessage = "Please enter atleast 5 characters")]
        [MaxLength(10, ErrorMessage = "Please enter max 10 characters")]
        public string UserName { get; set; }


        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email is required !")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }



        [DisplayName("First Name ")] // Annotation
        [Required(ErrorMessage = "Please enter your firstname properly !")]
        [RegularExpression(@"^[A-Za-z]{2,30}$", ErrorMessage = "Enter a valid first name (Only alphabets, minimum 2 characters)")]
        public string FirstName { get; set; }

        [DisplayName("Last Name ")] // Annotation
        public string LastName { get; set; }


        public bool IsActive { get; set; } = true;

        public string Gender { get; set; }

        [DisplayName("Age")] // Annotation
        [Required(ErrorMessage = "Please enter your Age")]
        [Range(18, 35, ErrorMessage = "Please enter your Age in between 18 to 35")]
        public int Age { get; set; }

        [DisplayName("Password")] // Annotation
        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$",
    ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]
        public string Password { get; set; }


        [DisplayName("ConfirmPassword")] // Annotation
        [Required(ErrorMessage = "Please enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password and password does not matched!!!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$",
    ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]
        public string ConfirmPassword { get; set; }



        public List<UserModel> UserList { get; set; }
    }
}