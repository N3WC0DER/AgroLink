using System.Collections;
using AgroLink.Server;
using Microsoft.EntityFrameworkCore;

var configuration = new WebApplicationOptions() { WebRootPath = "../agrolink.client/", Args = args };

var builder = WebApplication.CreateBuilder(configuration);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ASPNETCORE_HTTPS_PORT
// ASPNETCORE_URLS
// TODO: replace to env variables!!!

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostOrigin",
        builder => builder.WithOrigins("https://localhost:24683")
                            .AllowAnyHeader()
                            .AllowAnyMethod());
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowLocalhostOrigin");

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
