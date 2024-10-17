
using System.Text.Json;
using Hoorcollege4._2.Models;
using Microsoft.AspNetCore.Routing;
using System.Text.Json.Serialization;

namespace Hoorcollege4._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MyContext>();
            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add identity
            builder.Services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<MyContext>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapIdentityApi<User>();
            app.Run();
        }
    }
}
