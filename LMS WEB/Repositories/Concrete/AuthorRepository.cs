using LMS_WEB.Data;
using LMS_WEB.Models.DbModels;
using LMS_WEB.Repositories.Abstract;

namespace LMS_WEB.Repositories.Concrete
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly AppDbContext _appDbContext;
        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //public async Task<List<VwAuthor>> GetAllAsync()
        //{
        //    return await _appDbContext.VwAuthors.ToListAsync();
        //}

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _appDbContext.Authors.FindAsync(id);
        }


        public int Add(Author author)
        {
            _appDbContext.Authors.Add(author);
            _appDbContext.SaveChanges();
            return author.Id;
        }

        public void Edit(Author author, int id)
        {
            var authorData = _appDbContext.Authors.Find(id);
            authorData.Name = author.Name;

            _appDbContext.Authors.Update(authorData);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _appDbContext.Authors.Find(id);
            _appDbContext.Authors.Remove(author);
            _appDbContext.SaveChanges();
        }



    }

}

