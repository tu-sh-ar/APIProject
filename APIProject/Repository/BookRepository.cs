using APIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<Books> Create(Books book)
        {
            _context.Books.Add(book); //tracks given entity. added state suvh that changed will happen when SaveChanges() will be called 
            await _context.SaveChangesAsync();//Saves all changes in this context // Entity core does not support parallel operation with one context
            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Books>> Get() => await _context.Books.ToListAsync();

        public async Task<Books> Get(int id) => await _context.Books.FindAsync(id);

        public async Task Update(Books book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }

       
    }
}
