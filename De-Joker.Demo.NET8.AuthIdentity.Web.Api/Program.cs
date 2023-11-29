using De_Joker.Demo.NET8.AuthIdentity.Repository;
using De_Joker.Demo.NET8.AuthIdentity.Repository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Demo of Auth Identiy .NET 8 needed code.
// This is not JWT. Yes it's a bearer token and is stateless but not the same format.
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();
builder.Services.AddDbContext<DemoDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<DemoDbContext>().AddApiEndpoints();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Demo of Auth Identiy .NET 8 needed code.
app.MapIdentityApi<User>();

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
