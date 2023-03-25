using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IReaderRepository
    {

        Task<List<Reader>> GetAllAsync();

        Task<Reader> GetByIdAsync(int id);
        int Add(Reader reader);
        void Edit(Reader reader);

        void Delete(int id);

    }
}
