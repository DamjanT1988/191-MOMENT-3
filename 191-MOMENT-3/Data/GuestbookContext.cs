using _191_MOMENT_3.Models;
using Microsoft.EntityFrameworkCore;


namespace _191_MOMENT_3_TEST1.Data
{
    public class GuestbookContext : DbContext
    {
        //constructor
        //store in variable options
        public GuestbookContext(DbContextOptions<GuestbookContext> options) : base(options)
        {

        }

        //connect to model
        public DbSet<GuestbookModel> guestbook { get; set; }
    }
}
