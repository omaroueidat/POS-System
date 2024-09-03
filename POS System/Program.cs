using Entities.Database_Context;
using Entities.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Services.Implementation;
using Services.Interfaces;
using System.Text;
using Entities.Models.SuperMarketModels;
using Microsoft.AspNetCore.Identity;
using POS_System.ExtensionClasses;
using Serilog;
using POS_System.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// inject Logger
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/POS_System_Log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


// Add services to the container.
builder.Services.AddControllers();

// Add the Services through extension method on the IServiceCollection interface
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();