using component.template.api.configuration.Database;
using component.template.api.domain.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace component.template.api.configuration.General
{

     public class DependencyInjectionConfig : IGeneralApiConfig
     {
          private IConfiguration _configuration { get;}
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

               services.AddDbContext<CosmosDbContextConfig>(o =>
                 o.UseCosmos(
                    _configuration["Database:EndpointUri"] ?? throw new ConfigurationNotFoundExceptionException("Database:EndpointUri"), 
                    _configuration["Database:PrimaryKey"] ?? throw new ConfigurationNotFoundExceptionException("Database:PrimaryKey"), 
                    _configuration["Database:DatabaseName"] ?? throw new ConfigurationNotFoundExceptionException("Database:DatabaseName"))
               );
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
          }

          private void BusinessBuilder(IServiceCollection services)
          {
               // services.AddScoped<IErrorHandle, ErrorHandle>();
               // services.AddScoped<domain.Interfaces.Business.IUser, business.UserBusiness>();
          }

          private void DataBuilder(IServiceCollection services)
          {
               // services.AddScoped<domain.Interfaces.Infrastructure.IUser, infrastructure.User>();

               //services.AddHttpClient<ServiceReferences.IRelationshipService, ServiceReferences.RelationshipService>((provider, client) =>
               //    client.BaseAddress = new Uri("https://localhost:7114"));
          }

     }
}