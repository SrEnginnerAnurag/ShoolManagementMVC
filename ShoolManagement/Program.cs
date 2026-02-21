
using Microsoft.EntityFrameworkCore;
using SchoolManagementBissuness.SchoolInterfaceService;
using SchoolManagementBissuness.SchoolProfile;
using SchoolResitrationModel.SchoolDbContext;

namespace ShoolManagement
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




            builder.Services.AddDbContext<SchoolManagementData>(res => 
            {
                res.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"),
                    b => b.MigrationsAssembly("ShoolManagementWebApiProject"));
            });


            builder.Services.AddScoped<ISchoolManagementService, SchoolManagementService>();


            builder.Services.AddAutoMapper(typeof(SchoolManagementProfile));
            /*
          Agar aap AddAutoMapper(typeof(SchoolManagementProfile)) ka use kar rahe hain, iska matlab hai ki aapne SchoolManagementProfile mein apni sari mappings define ki hain. Isliye jab aap ye likhte hain, toh AutoMapper uss specific profile ko dekh kar mappings apply karta hai.

              Agar aap AddAutoMapper(typeof(Program)) ka use karte hain, toh AutoMapper ko kisi specific profile ki information nahi milti, aur wo default behavior follow karta hai jo kabhi-kabhi mappings detect nahi kar pata.*/




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
