using component.template.api.domain.Exceptions;
using component.template.api.domain.Interfaces.Handle;
using component.template.api.domain.Interfaces.Infrastructure.Repository;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.Handle;
using component.template.api.domain.Models.Repository.Contexts;
using component.template.api.infrastructure.Repository.SqlServer;
using component.template.api.infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace component.template.api.configuration.General
{

    public class DependencyInjectionConfig : IGeneralApiConfig
     {
          private IConfiguration _configuration { get; }
          public DependencyInjectionConfig(IConfiguration configuration)
          {
               _configuration = configuration;
          }

          public void Initialize(IServiceCollection services)
          {
               DatabaseBuilder(services);
               ServiceBuilder(services);
               BusinessBuilder(services);
               DataBuilder(services);
          }

          private void DatabaseBuilder(IServiceCollection services)
          {
               //services.AddDbContext<infrastructure.Context.CosmosContext>(o =>
               //   o.UseCosmos("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "gpsocial-dev"));

               if (bool.TryParse(_configuration["Database:Cosmos:Active"], out bool cosmosActive))
               {
                    services.AddDbContext<CosmosContext>(o =>
                      o.UseCosmos(
                         _configuration["Database:Cosmos:ConnectionString"] ?? throw new ConfigurationNotFoundExceptionException("Database:Cosmos:ConnectionString"),
                         _configuration["Database:Cosmos:DatabaseName"] ?? throw new ConfigurationNotFoundExceptionException("Database:Cosmos:DatabaseName")
                      )
                    );
               }
               if (bool.TryParse(_configuration["Database:Sql:Active"], out bool sqlActive))
               {
                    services.AddDbContext<SqlContext>(options =>
                         options.UseSqlServer(_configuration["Database:Sql:ConnectionString"]));
               }              
          }

          private void ServiceBuilder(IServiceCollection services)
          {
               // services.AddScoped<ServiceReferences.IRelationshipService>(_ =>
               //   new ServiceReferences.RelationshipService(
               //           _configuration["Services:Relationship:Uri"],
               //           new()
               //           {
               //                BaseAddress = new Uri(_configuration["Services:Relationship:Uri"])
               //           }
               //   ));

               //services.AddHttpClient<ServiceReferences.IRelationshipService, ServiceReferences.RelationshipService>((provider, client) =>
               //    client.BaseAddress = new Uri("https://localhost:7114"));
          }

          private void BusinessBuilder(IServiceCollection services)
          {
               services.AddScoped<IErrorHandle, ErrorHandle>();
               services.AddScoped<domain.Interfaces.Business.IWeatherForecastBusiness, business.WeatherForecastBusiness>();
          }

          private void DataBuilder(IServiceCollection services)
          {
               services.AddScoped<IUserRepository, UserRepository>();
               services.AddScoped<IProfileRepository, ProfileRepository>();
               services.AddScoped<IPermissionRepository, PermissionRepository>();
               services.AddScoped<IUserProfileRepository, UserProfileRepository>();
               services.AddScoped<IProfilePermissionRepository, ProfilePermissionRepository>();
               services.AddScoped<IUnitOfWork, UnitOfWorkForSql>();           
          }
     }
}