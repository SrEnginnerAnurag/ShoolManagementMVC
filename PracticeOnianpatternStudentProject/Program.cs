
using BussinessLogic.RepositoryFolder;
using BussinessLogic.RepositoryFolder.ServiceFolder;
using BussinessLogic.StudentMapperProfile;
using Microsoft.EntityFrameworkCore;
using model.DbContextFolder;

namespace PracticeOnianpatternStudentProject
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


            builder.Services.AddDbContext<StudentDbContext>( res => 
            {
                res.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"));
            });


            builder.Services.AddScoped<IStudentServicecs, StudentService>();


            builder.Services.AddAutoMapper(typeof(StudentProfile)); // mrea profile Class kaha Uss ko yak likhata hai

            var app = builder.Build();

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
