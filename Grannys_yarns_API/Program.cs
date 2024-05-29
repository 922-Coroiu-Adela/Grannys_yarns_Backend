using Grannys_yarns_API.Data;
using Grannys_yarns_API.Repository;
using Microsoft.EntityFrameworkCore;
using Grannys_yarns_API.Services;

namespace Grannys_yarns_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSingleton<iRepository, MemoryRepository>();
            //builder.Services.AddSingleton<iService, Service>();

            builder.Services.AddScoped<iRepository, SqlRepository>();
            builder.Services.AddScoped<iService, Service>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection2"));
            });

            

            var app = builder.Build();

            
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true));
                
            app.UseAuthorization();

            app.UseMiddleware<TokenValidationMiddleware>();

            app.MapControllers();

            app.Run();
        }   
    }
}