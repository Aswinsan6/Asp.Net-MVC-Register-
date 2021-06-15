using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginTask.Models
{
    public class UserModel
    {

        public int UserId { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage ="First Name is Required")]
        [Display(Name ="Enter First Name:")]
        public string FirstName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required")]
        [Display(Name = "Enter Last Name:")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        [Display(Name = "Enter Email:")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [Display(Name = "Enter Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        


        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required")]
        [Display(Name = "Enter Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage = "Password and Confirm Password Should be Same")]
        public string ConfirmPassword { get; set; }


       
        public DateTime CreatedOn { get; set; }

        public string SuccessMessage { get; set; }

    }
}