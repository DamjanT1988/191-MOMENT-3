using _191_MOMENT_3.Models;
using Microsoft.EntityFrameworkCore;


namespace _191_MOMENT_3.Data
{
    public class LibraryContext : DbContext
    {
        //constructor
        //store in variable options
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        //connect to model
        public DbSet<LibraryModel> mainLibrary { get; set; }
    }
}
