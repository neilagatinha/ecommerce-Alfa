using ecommerce_db.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var _mySqlaServerVersion = new MySqlServerVersion(new Version(8, 0, 33));

            builder.Services.AddDbContext<AppDbContext>(
                options => {
                    options.UseMySql(
                        builder.Configuration.GetConnectionString("DBString"),
                        _mySqlaServerVersion,
                        option => option.EnableRetryOnFailure()
                    );
                }
            ); 

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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