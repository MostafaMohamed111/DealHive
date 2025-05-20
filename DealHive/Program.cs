
using System.Data;
using System.Data.Common;
using System.Text;
using DealHive.Extentions;
using Hive.Application.JwtSettingsConfigurations;
using Hive.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DealHive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            
            builder.Services.UseProgramServices(builder);

            

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    var key = builder.Configuration["JwtSettings:Key"]
                        ?? throw new InvalidOperationException("JWT key is missing in configuration.");

                    var clockSkewHoursString = builder.Configuration["JwtSettings:DurationInMinutes"]
                        ?? throw new InvalidOperationException("Clock skew value missing.");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true, 
                        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                        ValidAudience = builder.Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)),
                        ClockSkew = TimeSpan.FromHours(double.Parse(clockSkewHoursString))
                    };
                });


            var app = builder.Build();
            
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); 

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
