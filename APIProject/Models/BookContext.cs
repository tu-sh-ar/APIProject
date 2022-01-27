using Microsoft.EntityFrameworkCore;

namespace APIProject.Models
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> option):base(option)
        {
            Database.EnsureCreated();// Ensures that the database is created
        }
        public DbSet<Books> Books { get; set; }//used to save query and instances of books
    }
}
