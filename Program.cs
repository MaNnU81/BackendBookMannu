using BackendBookMannu.Data;
using BackendBookMannu.Services;
using BackendBookMannu.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BackendBookMannu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddDbContext<LibraryContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            // Registrazione servizi
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddControllers();

            // Configurazione Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Library API",
                    Version = "v1",
                    Description = "API for managing Books and Categories"
                });
            });

            // Configurazione CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins(
                                "http://localhost:4200",  // Angular default port
                                "https://localhost:4200", // Angular with HTTPS
                                "http://localhost:5173",  // Vite default port
                                "https://localhost:5173"  // Vite with HTTPS
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials(); // Se usi cookie-based auth
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
                });
            }
            
        
            app.UseRouting();
            app.UseCors("AllowFrontend"); 
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}