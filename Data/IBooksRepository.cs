using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Data {
    public interface IBooksRepository {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> GetBooksAsync(int[] ids);
        Task<Book> GetBookAsync(int id);
        void CreateBook(Book book);
        Task<bool> SaveChangesAsync();
    }
}