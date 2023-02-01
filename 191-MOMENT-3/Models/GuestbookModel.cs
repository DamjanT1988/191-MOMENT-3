using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace _191_MOMENT_3.Models
{
    public class GuestbookModel
    {
        //Properties
        //ID = auto
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Message { get; set; }
        //DATE = auto
        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}