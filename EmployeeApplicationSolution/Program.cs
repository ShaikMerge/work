
using EmployeeApplicationSolution.Interfaces;
using EmployeeApplicationSolution.Models;
using EmployeeApplicationSolution.Repositories;
using EmployeeApplicationSolution.Services;

namespace EmployeeApplicationSolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepository<Employee, int>, EmployeeRepository>();//Injected the Repository

            builder.Services.AddScoped<IEmployeeGeneralService, EmployeeGeneralService>();//Injected the Service
            builder.Services.AddScoped<IEmployeeSuplierService, EmployeeSupplierService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
