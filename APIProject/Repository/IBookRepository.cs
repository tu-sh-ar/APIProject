using APIProject.Models;
namespace APIProject.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> Get();//Threading.Tasks.Task
        Task<Books> Get(int id);
        Task<Books> Create(Books book);
        Task Update(Books book);
        Task Delete(int id);
    }
}
