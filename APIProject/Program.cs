using APIProject.Models;
using APIProject.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //imp

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ));
builder.Services.AddScoped<IBookRepository, BookRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  //registers Swagger middlewaare for DI
    app.UseSwaggerUI();//registers Swagger UI middleware for DI
}

//app.UseHttpsRedirection();//Adds middleware to redirect http to https

app.UseAuthorization();//Routing Concept

app.MapControllers();

app.Run();
