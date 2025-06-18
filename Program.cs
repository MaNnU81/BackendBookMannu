
using BackendBookMannu.Data;
using BackendBookMannu.Services;
using BackendBookMannu.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

namespace BackendBookMannu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<LibraryContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v3", new OpenApiInfo
    {
        Title = "Identity API",
        Version = "v3",
        Description = "API for managing Users."
    })
);


            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library API", Version = "v1" });
            });


            var app = builder.Build();
            app.UseSwagger();  // Nessuna configurazione custom necessaria
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
