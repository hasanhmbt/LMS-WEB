using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IAuthorRepository
    {
        Task<List<VwAuthor>> GetAllAsync(int authorId,string searchText="");

        Task<Author> GetByIdAsync(int id);
        int Add(Author author);
        void Edit(Author author);

        void Delete(int id);


    }
}
