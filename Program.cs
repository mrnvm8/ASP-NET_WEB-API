using ASP_NET_WEB_API.Data;
using ASP_NET_WEB_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Add services for Mysql to be used in runtime
builder.Services.AddDbContext<DBAccess>(options => 
        options.UseMySQL(builder.Configuration.GetConnectionString("DataContext")));

//To Enable cross origin resource sharing(CORS) with angular app
//Enable CORS
// builder.Services.AddCors(options => {
//     options.AddPolicy(name: myAllowSpecificOrigins,
//     builder =>
//     {
//         builder.WithOrigins("http://localhost:4200")
//         .AllowAnyMethod()
//         .AllowAnyHeader();
//     });
// });


// Registering the BookRepository for use at runtime
// Dependency Injection
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Tell App to use CORS
//app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
