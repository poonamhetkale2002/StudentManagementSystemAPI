using StudentManagementSystemAPI.Repositories;
using StudentManagementSystemAPI.Services;
using Serilog;
using StudentManagementSystemAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Serilog setup
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            builder.Host.UseSerilog();

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found")));

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            /*builder.Services.AddAuthentication("JwtBearer").AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(
             Encoding.UTF8.GetBytes("MySecretKey12345")),
         ValidateIssuer = false,
         ValidateAudience = false
     };
 });

             app.UseAuthentication();*/

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
