global using shereeni_dotnet.Models;
global using shereeni_dotnet.Data;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using shereeni_dotnet.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddDbContext<DataContext>();

// used to overcome the reference looping or cycle error while querying data using relations -> new built in
// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
// });

// to overcome the reference issue or object reference cycle issue. -> third party
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// for express - put this in the config.
// "DefaultConnection": "Server=.\\sqlexpress;Database=shereeni;Trusted_Connection=True;TrustServerCertificate=True"
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

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