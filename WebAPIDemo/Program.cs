using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPIDemo.Entites;
using WebAPIDemo.Repositories;
using WebAPIDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:defaultConnection").Value));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIDemo", Version = "v1" });
});
// add the services to the project container -> to inject all services we use AddScoped
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIDemo v1"));

app.Run();
