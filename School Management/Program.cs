using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School_Management.Data;
using School_Management.Interface_Repository;
using School_Management.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connect Database
builder.Services.AddDbContext<SchoolDbContext>(option =>
{
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolDbConnectionString"));
});

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
