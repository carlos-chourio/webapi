using System;
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
                Description = "The book represents a series of murders and homicides that have been made by some misterious Guy named mr. Brown " +
                "and calls the attention of two young investigators named Tommy and Tuppence who try to stop him",
                AuthorId = 2
            });
        }

        public async Task<IEnumerable<Book>> GetBooksAsync() {
            Author author = new Author() {
                Id = 1, Birthday = DateTime.Today - TimeSpan.FromDays(365*23), DateOfDeath = DateTime.Now, FirstName = "Cristina", LastName = "Green"
            };
            IEnumerable<Book> books = new List<Book>() {
                new Book() {
                   Id = 1,
                   Title = "Misterious Mr. Brown",
                   Description = "The book represents a series of murders and homicides that have been made by some misterious Guy named mr. Brown " +
                   "and calls the attention of two young investigators named Tommy and Tuppence who try to stop him",
                   AuthorId = author.Id,
                   Author = author
               }
            };
            return await Task.FromResult(books);
        }

        
        public void CreateBook(Book book) {
            // throw new System.NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync() {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(int[] ids) {
            return await GetBooksAsync();
        }
    }
}