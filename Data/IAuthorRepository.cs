using System.Threading.Tasks;

namespace WebApi.Data {
    public interface IAuthorRepository {
        Task<bool> AuthorExistsAsync();
    }
}