using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DbModel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFrameworkExt(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ViLabContext>(options =>
                options.UseNpgsql(connectionString));
        }
    }
}
