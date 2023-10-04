using ecommerce_db.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db
{
    public class Startup{
        public Startup(IConfiguration configuration) {
            
                Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            var _mySqlaServerVersion = new MySqlServerVersion(new Version(8, 0, 33));

            services.AddDbContext<AppDbContext>(
                options => {
                    options.UseMySql(
                           Configuration.GetConnectionString("DBString"),
                        _mySqlaServerVersion,
                        option => option.EnableRetryOnFailure()
                    );
                }
            );

            services.AddRazorPages();

        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();

        }

    }
}
