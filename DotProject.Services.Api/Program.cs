using DotProject.Infra.Data.Context;
using DotProject.Services.Api.Configurations;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Identity.User;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddAspNetUserConfiguration();

// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// Swagger Config
builder.Services.AddSwaggerConfiguration();

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    using (var scope = app.Services.CreateScope())
    {
        var dotProjectContext = scope.ServiceProvider.GetRequiredService<DotProjectContext>();        
        dotProjectContext.Database.Migrate();

        var eventStoreSqlContext = scope.ServiceProvider.GetRequiredService<EventStoreSqlContext>();        
        eventStoreSqlContext.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerSetup();

app.Run();
