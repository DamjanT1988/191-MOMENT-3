using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _191_MOMENT_3.Models
{
    public class GuestbookModel
    {
        //Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}