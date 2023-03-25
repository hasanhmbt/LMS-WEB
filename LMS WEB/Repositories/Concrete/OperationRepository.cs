using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories.Concrete
{
    public class OperationRepository: IOperationRepository
    {


        private readonly AppDbContext _appDbContext;
        public OperationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<List<VwOperation>> GetAllAsync()
        {
            return await _appDbContext.VwOperations.ToListAsync();
        }

        public async Task<Operation> GetByIdAsync(int id)
        {
            return await _appDbContext.Operations.FindAsync(id);
        }


        public int Add(Operation operation)
        {
            _appDbContext.Operations.Add(operation);
            _appDbContext.SaveChanges();
            return operation.Id;
        }

        public void Edit(Operation operation   )
        {
            _appDbContext.Operations.Update(operation);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var operation = _appDbContext.Operations.Find(id);
            _appDbContext.Operations.Remove(operation);
            _appDbContext.SaveChanges();
        }



    }
}
