using CleanArchi.Application.Repository;
using CleanArchi.Application.Services;
using CleanArchi.Application.Services.Interfaces;
using CleanArchi.Infrastructure;
using CleanArchi.Application;
using Microsoft.Extensions.Configuration;
using System;
using CleanArchi.Infrastructure.Data;
using CleanArchi.Infrastructure.Identity.Model;
var builder = WebApplication.CreateBuilder(args);

// Add the authorization services
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddApplicationServices(); 
builder.Services.AddInfrastructureServices(builder.Configuration, "DefaultConnection");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();


//Add Identity endpoint
builder.Services
				.AddIdentityApiEndpoints<ApplicationUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//Map identity
app.MapGroup("/account").MapIdentityApi<ApplicationUser>();

app.MapControllers();

app.Run();
