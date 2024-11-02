using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GrpcService1.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;



namespace GrpcService1.Configurations;


public static class AuthConfigurations
{
  public static IServiceCollection SetMyVaccineAuthConfiguration(this IServiceCollection services)
  { 
    services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit= true;
        options.Password.RequireLowercase= true;
        options.Password.RequireUppercase=true;
        options.Password.RequireNonAlphanumeric=true;
        options.Password.RequiredLength = 8;
    }
    ).AddEntityFrameworkStores<MyVaccineAppDbContext>()
    .AddDefaultTokenProviders();

    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
      options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
      

    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer= false,
            ValidateAudience= false,
            ValidateLifetime=true,
            ValidateIssuerSigningKey= false,

        };
    });
    
    return services;
  }
}

