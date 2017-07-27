using System.IO;
using System.Text;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.SharedInterfaces;
using Amazon.S3;
using Common.MailService;
using DbModel;
using DbModel.Entities;
using DbModel.Extensions;
using DbModel.Repositories;
using DbModel.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using VILab.API.Dto.Create;
using VILab.API.Dto.Retrieve;
using VILab.API.Dto.Update;
using VILab.API.Services.S3Service;

namespace VILab.API
{
  public class Startup
  {
    public static IConfigurationRoot Configuration;
    private static IHostingEnvironment _environment;

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();

      Configuration = builder.Build();
      _environment = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddTransient<IMailService, LocalMailService>();

      var connectionString = Startup.Configuration["connectionStrings:VILabDBConnectionString"];
      services.AddEntityFrameworkExt(connectionString);

      services.AddMvc(opt =>
      {
        if (!_environment.IsProduction())
        {
          opt.SslPort = 44351;
        }
        opt.Filters.Add(new RequireHttpsAttribute());
      });

      services.AddScoped<IVILabRepository, VILabRepository>();
      services.AddScoped<IS3Service, S3Service>();

      services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
      services.AddAWSService<IAmazonS3>();

      services.AddIdentityExt();

      services.AddAuthorization(cfg =>
      {
        cfg.AddPolicy("SuperUsers", p => p.RequireClaim("SuperUser", "True"));
      });

      services.AddTransient<IdentitySeeder>();

      var corsBuilder = SetupCorsBuilder();
      services.AddCors(options =>
      {
        options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
      });
    }

    private CorsPolicyBuilder SetupCorsBuilder()
    {
      var corsBuilder = new CorsPolicyBuilder();
      corsBuilder.AllowAnyHeader();
      corsBuilder.AllowAnyMethod();
      corsBuilder.AllowAnyOrigin();
      corsBuilder.AllowCredentials();

      return corsBuilder;
    }


    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ViLabContext viLabContext, IdentitySeeder identitySeeder )
    {
      loggerFactory.AddConsole();
      loggerFactory.AddNLog();
      loggerFactory.ConfigureNLog(Path.Combine(env.ContentRootPath, "nlog.config"));

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler();
      }

      viLabContext.EnsureSeedDataForContext();

      app.UseStatusCodePages();

      AutoMapper.Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<City, CityWithoutPointsOfInterestDto>();
        cfg.CreateMap<City, CityDto>();
        cfg.CreateMap<PointOfInterest, PointOfInterestDto>();
        cfg.CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
        cfg.CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();
        cfg.CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
      });

      //InitAwsCredetialsFile();
      app.UseIdentity();

      app.UseJwtBearerAuthentication(new JwtBearerOptions()
      {
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        TokenValidationParameters = new TokenValidationParameters()
        {
          ValidIssuer = Configuration["Tokens:Issuer"],
          ValidAudience = Configuration["Tokens:Audience"],
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
          ValidateLifetime = true
        }
      });

      app.UseMvc();

      //identitySeeder.Seed().Wait();
    }

    private void InitAwsCredetialsFile()
    {
      var options = new CredentialProfileOptions()
      {
        AccessKey = "",
        SecretKey = ""
      };
      var profile = new CredentialProfile("vilab_profile", options) { Region = RegionEndpoint.EUCentral1 };
      var sharedFile = new SharedCredentialsFile();
      sharedFile.RegisterProfile(profile);
    }
  }
}
