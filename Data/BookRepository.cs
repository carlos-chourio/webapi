using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Entities;
using WebApi.Entities.External;

namespace WebApi.Data {
    public class BookRepository : IBookRepository {
        private readonly WebApiContext context;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<BookRepository> logger;
        private CancellationTokenSource cancellationTokenSource;

        public BookRepository(WebApiContext context, IHttpClientFactory httpClientFactory, ILogger<BookRepository> logger) {
            this.context = context;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public void CreateBook(Book book) {
            context.Book.Add(book);
        }

        public async Task<Book> GetBookAsync(int id) {
            return await context.Book.FindAsync(id);
        }

        public async Task<BookCover> GetBookCoverAsync(string coverId) {
            using (var httpClient = httpClientFactory.CreateClient()) {
                return await DownloadBookCover(httpClient, $"https://localhost:44390/api/bookcover/{coverId}", CancellationToken.None);
            }
        }

        private async Task<BookCover> DownloadBookCover(HttpClient httpClient, string url, CancellationToken cancellationToken) {
            var response = await httpClient.GetAsync(url, cancellationToken);
            if (response.IsSuccessStatusCode) {
                return JsonConvert.DeserializeObject<BookCover>(await response.Content.ReadAsStringAsync());
            }
            cancellationTokenSource.Cancel();
            return null;
        }

        public async Task<IEnumerable<BookCover>> GetBookCoversAsync(string coverId) {
            using (cancellationTokenSource = new CancellationTokenSource()) {
                string[] bookCoverUrls = {
                "https://localhost:44390/api/bookcover/{coverId}-dummy-cover-1",
                "https://localhost:44390/api/bookcover/{coverId}-dummy-cover-2",
                "https://localhost:44390/api/bookcover/{coverId}-dummy-cover-3",
                "https://localhost:44390/api/bookcover/{coverId}-dummy-cover-4",
                "https://localhost:44390/api/bookcover/{coverId}-dummy-cover-5"
                };
                using (var httpClient = httpClientFactory.CreateClient()) {
                    var bookCoversTaskCollection = bookCoverUrls.Select(bookCover => DownloadBookCover(httpClient, bookCover, cancellationTokenSource.Token)).ToList();
                    try {
                        return await Task.WhenAll(bookCoversTaskCollection);
                    } catch (OperationCanceledException opCanceledEx) {
                        return null;
                    }
                }
            }
        }

            public async Task<IEnumerable<Book>> GetBooksAsync() {
            return await context.Book.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(int[] ids) {
            return await context.Book.Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync() {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
