
using BackendBookMannu.Models.Dto;

namespace BackendBookMannu.Services.Interface
{
    public interface IBookService
    {
        
        Task<BookDTO?> CreateBook(CreateBookDTO book);
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<BookDTO?> GetBookById(int id);
        Task<IEnumerable<BookDTO>> GetBooksByCategoryId(int categoryId);
        Task<IEnumerable<BookDTO>> GetBooksByTitle(string title);
    }
}
