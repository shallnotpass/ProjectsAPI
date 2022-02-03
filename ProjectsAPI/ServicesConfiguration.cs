using Microsoft.EntityFrameworkCore;
using ProjectAPI.DataAccess;
using ProjectAPI.Logic.Contracts;
using ProjectAPI.Logic;

namespace ProjectsAPI
{
    public static class ServicesConfiguration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IProjectService, ProjectService>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
