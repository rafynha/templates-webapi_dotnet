using component.template.api.configuration;
using component.template.api.configuration.General;
using component.template.api.domain.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ServiceExceptionFilter>();
    options.Filters.Add<ServiceResultFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API NAME",
                    Version = "v1",
                    Description = "Api description",
                    Contact = new OpenApiContact()
                    {
                        Name = "",
                        Email = "",
                        Url = new Uri("https://contactsite.com/")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Copyright XXX © 2022",
                        Url = new Uri("https://license.com/")
                    }
                });
            });

builder.Services.AddConfiguration(new DependencyInjectionConfig(builder.Configuration));



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();