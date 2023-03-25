using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Repositories.Abstract
{
    public interface IOperationRepository
    {

        Task<List<VwOperation>> GetAllAsync();

        Task<Operation> GetByIdAsync(int id);
        int Add(Operation operation);
        void Edit(Operation operation);

        void Delete(int id);


    }
}
