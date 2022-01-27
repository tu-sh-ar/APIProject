using APIProject.Models;
using APIProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("")] //identifies HttpGet methods
        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")] //identifies HttpGet methods
        public async Task<ActionResult<Books>> GetBooks([FromBody]Books book)// id is a URI
        {
            return await _bookRepository.Get(book.Id);
        }

        [HttpPost("")] //identifies HttpPost methods
        public async Task<ActionResult<Books>> PostBooks([FromBody]Books book)//from body bindes using request body
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {id = newBook.Id},newBook);
        }


        [HttpPut("")] //identifies HttpPut methods
        public async Task<ActionResult<Books>> PutBooks(int id,[FromBody]Books book)
        {
            if(id != book.Id) {
                return BadRequest();//returns 404 status code
                
                    
            }
            await _bookRepository.Update(book);
            return NoContent();// returns 204 status code
        }
    }
}
