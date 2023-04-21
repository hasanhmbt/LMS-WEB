namespace LMS_WEB.Models.DbModels
{
    public class DashboardData
    {
        public FncDashboardCounts? DashboardCounts { get; set; }

        public MostOrderedBookModel? MostOrderedBooks { get; set;}

        public TotalOrderModel? TotalOrderBooks { get; set; } 

    }
}
