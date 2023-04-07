using Microsoft.EntityFrameworkCore;
using LMS_WEB.Models;
using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Data
{
    public class AppFuncContext : AppDbContext
    {
        public AppFuncContext()
        {
        }

        public AppFuncContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public IQueryable<FncDashboardCounts> FncDashboardCounts(string beginDate, string endDate)
        => FromExpression(() => FncDashboardCounts(beginDate, endDate));
        public IQueryable<FncGetBookRemainder> FncGetBookRemainder(int id, int saleId)
        => FromExpression(() => FncGetBookRemainder(id, saleId));

        public IQueryable<FncMostOrderedBooks> FncMostOrderedBooks(string beginDate, string endDate)
        => FromExpression(() => FncMostOrderedBooks(beginDate, endDate));




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(AppFuncContext).GetMethod(nameof(FncDashboardCounts), new[] { typeof(string), typeof(string) }));
            modelBuilder.HasDbFunction(typeof(AppFuncContext).GetMethod(nameof(FncGetBookRemainder), new[] { typeof(int), typeof(int) }));
            modelBuilder.HasDbFunction(typeof(AppFuncContext).GetMethod(nameof(FncMostOrderedBooks), new[] { typeof(string), typeof(string) }));
        }
    }
}
