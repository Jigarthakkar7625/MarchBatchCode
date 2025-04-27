using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyFirstMVCApplication.Models
{
    public class RegisterModel
    {
        public int UserId { get; set; } = 10;
        public string UserName { get; set; }

        public string Password { get; set; }

        [DisplayName("First Name ")] // Annotation
        public string FirstName { get; set; }

        [DisplayName("Last Name ")] // Annotation
        public string LastName { get; set; }


        public bool IsActive { get; set; } = true;

        public string Gender { get; set; }

        public List<UserModel> UserList { get; set; }
    }
}