using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Entities.External;

namespace WebApi.Data {
    public interface IBookRepository {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> GetBooksAsync(int[] ids);
        Task<Book> GetBookAsync(int id);
        void CreateBook(Book book);
        Task<bool> SaveChangesAsync();
        Task<BookCover> GetBookCoverAsync(string coverId);
        Task<IEnumerable<BookCover>> GetBookCoversAsync(string coverId);
    }
}