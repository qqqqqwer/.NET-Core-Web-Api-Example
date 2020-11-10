using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FSCC.Database;
using FSCC.Services;
using FSCC.Services.Abstractions;
using FSCC.Database.Repositories.Abstractions;
using FSCC.Database.Repositories;

namespace FSCC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IRequestInfoService, RequestInfoService>();

            //Repos
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IRequestInfoRepository, RequestInfoRepository>();

            //Database
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FSCCDBConString"), b => b.MigrationsAssembly("FSCC.Database")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext databaseContext)
        {
            databaseContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
