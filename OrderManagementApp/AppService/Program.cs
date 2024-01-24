using Domain;
using Microsoft.EntityFrameworkCore;

namespace AppService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<RestaurantDbContext>(options =>
           options.UseSqlServer(builder.Configuration.
               GetConnectionString("OrderManagementDb")));
            builder.Services.AddGraphQLServer()
                .AddDomainTypes();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseRouting();// to UseRouting middleware should added before UseEndpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
            app.Run();
        }
    }
}