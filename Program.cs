using Microsoft.EntityFrameworkCore;
using microWise_Tracking_System.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//db context
builder.Services.AddDbContext<MicroWiseDbContext>
    (
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("con"))
    );




builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
