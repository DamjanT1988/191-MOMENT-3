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
        [Required]
        public string? Artist { get; set; }
        [Required]
        public string? Album { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public int? Minutes { get; set; }
        //DATE = auto
        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}