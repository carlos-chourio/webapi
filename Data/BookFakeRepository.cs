using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Data {
    public class BookFakeRepository : IBooksRepository {
        public async Task<Book> GetBookAsync(int id) {
            return await Task.FromResult(new Book()
            {
                Id = 1,
                Title = "Misterious Mr. Brown",
                Descrition = "The book represents a series of murders and homicides that have been made by some misterious Guy named mr. Brown " +
                "and calls the attention of two young investigators named Tommy and Tuppence who try to stop him",
                AuthorId = 2
            });
        }

        public async Task<IEnumerable<Book>> GetBooksAsync() {
            IEnumerable<Book> books = new List<Book>() {
                new Book() {
                   Id = 1,
                   Title = "Misterious Mr. Brown",
                   Descrition = "The book represents a series of murders and homicides that have been made by some misterious Guy named mr. Brown " +
                "and calls the attention of two young investigators named Tommy and Tuppence who try to stop him",
                   AuthorId = 2
               }
            };
            return await Task.FromResult(books);
        }

    }
}