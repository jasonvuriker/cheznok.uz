using cheznok.uz.Entities;
using cheznok.uz.Middlewares;
using cheznok.uz.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ChesnokContext>(options =>
{
    options
        .UseNpgsql(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddTransient<AuthenticationMiddleware>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFoodService, FoodService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<ImageResizeMiddleware>();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/StaticFiles",

});

app.MapControllers();

app.Run();
