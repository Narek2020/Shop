using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [MinLength(3, ErrorMessage = "Field must be more then 3 character")]
        public string Password { get; set; }
        public bool Status  { get; set; }

        public bool Checked { get; set; }
    }
}
//[Required(ErrorMessage = "Password is required")]
//[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
//[DataType(DataType.Password)]
//public string Password { get; set; }

//[Required(ErrorMessage = "Confirm Password is required")]
//[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
//[DataType(DataType.Password)]
//[Compare("Password")]
//public string ConfirmPassword { get; set; }