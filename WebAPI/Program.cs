using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolves.Autofac;
using Autofac.Core;
using Core.DependencyResolves;
using Core.Utilities.IoC;
using System.Configuration;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Encryption;
using Core.Extensions;
using Core.Utilities.HeaderParameter;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using NLog.Web;
using WebAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Business.BusinessRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddControllers();


var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<AuthController>();
builder.Services.AddTransient<LessonBusinuessRules>();
builder.Services.AddTransient<SessionBusinessRules>();
builder.Services.AddSwaggerGen(
  c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
      c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
          Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
      });

      c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

  }
    );

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
  new CoreModule()

});


builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500").SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("http://127.0.0.1:3000").AllowAnyHeader()
                    .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader()
                    .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("http://194.27.244.133:443").AllowAnyHeader()
                    .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("http://127.0.0.1:7067").AllowAnyHeader()
                   .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("https://localhost:7067").AllowAnyHeader()
                   .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("*").AllowAnyHeader()
                   .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("https://78.189.143.34:443").AllowAnyHeader()
                    .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("https://78.189.143.34:7067").AllowAnyHeader()
                .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                  policy.WithOrigins("http://78.189.143.34:80").AllowAnyHeader()
                .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("https://88.230.173.137/443").AllowAnyHeader()
               .AllowAnyMethod().SetIsOriginAllowed(origin => true);
                          policy.WithOrigins("http://88.230.173.137/80").AllowAnyHeader()
              .AllowAnyMethod().SetIsOriginAllowed(origin => true);

                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lotus.API.Integration v1"));
}
app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
   pattern: "{controller=swagger}/{action=Index}/{id?}");
app.UseCors(MyAllowSpecificOrigins);
app.Run();
