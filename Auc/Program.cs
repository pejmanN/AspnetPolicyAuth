using Auc.Common.Authentication;
using Auc.Common.Authrization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication()
              .AddJwtBearer(TokenSchemes.SSO, options =>
              {
                  //Its better to read the values form appsetting
                  options.Audience = "Auc-API";               
                  options.Authority = "http://localhost:8081/realms/AucRealm";
                  options.MapInboundClaims = false;

                  //since we are running KeyClock on http 
                  options.RequireHttpsMetadata = false;

                  //you can use following for add or remove criteria from validaion process
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      
                      RoleClaimType = "role",  //Sets which claim should be used for user roles.
                      NameClaimType = "preferred_username"  //Defines which claim should be used for the username.
                  };
              });

builder.AddAuthorization();

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
