using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src.config;
using ProductAppAsync.src.services;
using ProductAppAsync.src.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<UserInterface, UserService>();

// Configure DbContext
builder.Services.AddDbContext<AppDBContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("mycon"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
