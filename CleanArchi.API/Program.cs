using CleanArchi.Application.Repository;
using CleanArchi.Application.Services;
using CleanArchi.Application.Services.Interfaces;
using CleanArchi.Infrastructure;
using CleanArchi.Application;
using Microsoft.Extensions.Configuration;
using System;
using CleanArchi.Infrastructure.Data;
using CleanArchi.Infrastructure.Identity.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using CleanArchi.API.infrastructure;
using Microsoft.VisualBasic.FileIO;
var builder = WebApplication.CreateBuilder(args);

// Add the authorization services
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration, "DefaultConnection");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "CleanArchi API",
		Description = "Simple exemple de clean architecture en Web Api .net8 + EFCore 8 + Identity",
		Contact = new OpenApiContact
		{
			Name = "Contact",
			Url = new Uri("https://www.cognitic.be/contactez-nous")
		}


	});
	// using System.Reflection;
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

	//Jwt
	// Bearer token authentication


	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
	});
	options.OperationFilter<AddAuthHeaderOperationFilter>();
	 

});

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
	app.UseStaticFiles(new StaticFileOptions
	{
		FileProvider = new PhysicalFileProvider(
	  Path.Combine(Directory.GetCurrentDirectory(), "assets")),
		RequestPath = "/assets"
	});
	app.UseSwagger(options =>
	{
		options.SerializeAsV2 = true;
	});
	app.UseSwaggerUI(c =>
	{
		c.DocumentTitle = "CleanArchi - Clean Architecture sample";
		c.InjectStylesheet("/assets/css/customswagger.css");
		c.InjectJavascript("../assets/swagger/iconswagger.js");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();
//Map identity
app.MapGroup("/account").MapIdentityApi<ApplicationUser>();

app.MapControllers();

app.Run();
