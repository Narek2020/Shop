using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public string Currency { get; set; }
        public Nullable<int> Category { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Dimention { get; set; }
        public string Material { get; set; }
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