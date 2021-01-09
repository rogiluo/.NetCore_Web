using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rogiluo.Common.DAL;

namespace Rogiluo.Website
{
    public class Startup
    {
        /// <summary>
        /// 設定檔
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 注入設定
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DbConnection"]));
        }

        /// <summary>
        /// 設定
        /// </summary>
        /// <param name="app"></param>
        /// <param name="dataContext"></param>
        public void Configure(IApplicationBuilder app, DataContext dataContext)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"));

            dataContext.Database.EnsureCreated();
        }
    }
}
