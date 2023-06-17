using WebAPIBLL.Interfaces.Sales;
using WebAPIBLL.Implementation.Sales;

namespace WebAPI.Configuration
{
    public static class DependecyInjection
    {
        public static void AddBLL(this IServiceCollection services)
        {
            services.AddScoped<ISalesReasonBLL, SalesReasonBLL>();
        }
    }
}
