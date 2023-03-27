using Microsoft.EntityFrameworkCore;
using LMS_WEB.Models;
using LMS_WEB.Models.DbModels;

namespace LMS_WEB.Data
{
    public class AppFuncContext:AppDbContext
    {
        public AppFuncContext()
        {
        }

        public AppFuncContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

      //  public IQueryable<FncDashboardCount> FncDashboardCounts(string beginDate, string endDate)
      //  => FromExpression(() => FncDashboardCounts(beginDate, endDate));

      //  public IQueryable<FncTotalEarning> FncTotalEarnings(string beginDate, string endDate)
      // => FromExpression(() => FncTotalEarnings(beginDate, endDate));

      //  public IQueryable<FncBestSellingProduct> FncBestSellingProducts(string beginDate, string endDate)
      //=> FromExpression(() => FncBestSellingProducts(beginDate, endDate));

      //  public IQueryable<FncProductRemainder> FncGetProductRemainder(int id, int saleId)
      //=> FromExpression(() => FncGetProductRemainder(id, saleId));

      //  protected override void OnModelCreating(ModelBuilder modelBuilder)
      //  {
      //      modelBuilder.HasDbFunction(typeof(AppFuncContext).GetMethod(nameof(FncDashboardCounts), new[] { typeof(string), typeof(string) }));
      //      modelBuilder.HasDbFunction(typeof(AppFuncContext).GetMethod(nameof(FncTotalEarnings), new[] { typeof(string), typeof(string) }));
      //      modelBuilder.HasDbFunction(typeof(AppFuncContext).GetMethod(nameof(FncBestSellingProducts), new[] { typeof(string), typeof(string) }));
      //      modelBuilder.HasDbFunction(typeof(AppFuncContext).GetMethod(nameof(FncGetProductRemainder), new[] { typeof(int), typeof(int) }));
      //  }
    }
}
