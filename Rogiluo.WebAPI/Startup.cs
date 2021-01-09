using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rogiluo.Common.DAL;

namespace Rogiluo.WebAPI
{
    /// <summary>
    /// �_�l�]�w
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// �]�w��
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// �غc�l
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        /// <summary>
        /// �`�J�]�w
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(options =>  options.UseSqlServer(Configuration["ConnectionStrings:DbConnection"]));
        }

        /// <summary>
        /// �]�w
        /// </summary>
        /// <param name="app"></param>
        /// <param name="dataContext"></param>
        public void Configure(IApplicationBuilder app, DataContext dataContext)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            dataContext.Database.EnsureCreated();
        }
    }
}
