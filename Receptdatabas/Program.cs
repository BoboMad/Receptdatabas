using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Receptdatabas.Repositories.Contexts;
using Receptdatabas.Repositories.Implementations;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Services.Implementations;
using Receptdatabas.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Receptdatabas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Receptdatabas", Version = "v1" });
            });

            builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer("Data Source=LAPTOP-RSRDNQGD\\MSSQLSERVER1;Initial Catalog=Receptdatabas;Integrated Security=SSPI;TrustServerCertificate=True;"));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receptdatabas v1");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run();
        }
    }
}
