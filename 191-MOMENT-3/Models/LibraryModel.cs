using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace _191_MOMENT_3.Models
{
    public class LibraryModel
    {
        //Properties
        //ID = auto, primary key (PK)
        public int Id { get; set; }
        //required to fill in to form
        [Required(ErrorMessage = "Please fill in the artist name!")]
        //display specific name
        [Display(Name = "Artist name:")]
        public string? Artist { get; set; }
        
        [Required(ErrorMessage = "Please fill in the album name!")]
        [Display(Name = "Album name:")]
        public string? Album { get; set; }

        [Required(ErrorMessage = "Please fill in the year number (yyyy)!")]
        [Display(Name = "Publishing year:")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please fill in the lenght number in minutes!")]
        [Display(Name = "Length (minutes):")]
        public int? Minutes { get; set; }
        //DATE = auto
        [Display(Name = "Created at:")]
        public DateTime PostedDate { get; set; } = DateTime.Now;

        //limits other types: email, phone, min.length etc
        // [DataType(DataType.EmailAddress)] - validate email
    }
}