using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Context;

namespace WebApi.Data {
    public class AuthorRepository : IAuthorRepository {
        private readonly WebApiContext context;

        public AuthorRepository(WebApiContext context) {
            this.context = context;
        }

        public async Task<bool> AuthorExistsAsync() {
            return await context.Author.AnyAsync();
        }

    }
}
