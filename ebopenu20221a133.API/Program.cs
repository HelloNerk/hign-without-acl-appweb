// <remarks>Documented by Joseph Alexis Huamani Mandujano</remarks>
using ebopenu20221a133.API.Shared.Domain.Repositories;
using ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ebopenu20221a133.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ebopenu20221a133.API.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ebopenu20221a133.API.Shared.Interfaces.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ebopenu20221a133.API.assessment.Application.Internal.CommandServices;
using ebopenu20221a133.API.assessment.Domain.Repositories;
using ebopenu20221a133.API.assessment.Domain.Services;
using ebopenu20221a133.API.assessment.Infrastructure.Persistence.EFC.Repositories;
using ebopenu20221a133.API.personnel.Application.Internal.CommandServices;
using ebopenu20221a133.API.personnel.Domain.Repositories;
using ebopenu20221a133.API.personnel.Domain.Services;
using ebopenu20221a133.API.personnel.Infrastructure.Persistence.EFC.Repositories;

// <remarks>Documented by Joseph Alexis Huamani Mandujano</remarks>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "si730pc2u20221a133.API",
                Version = "v1",
                Description = "U20221a133 Documentation API",
                TermsOfService = new Uri("https://joinrequest.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "U20221a133 Studios",
                    Email = "contact@u20221a133.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Hr Bounded Context Injection Configuration
//builder.Services.AddScoped<IJoinRequestRepository, JoinRequestRepository>();
//builder.Services.AddScoped<IJoinRequestCommandService, JoinRequestCommandService>();
builder.Services.AddScoped<IExaminerRepository, ExaminerRepository>();
builder.Services.AddScoped<IExaminerCommandService, ExaminerCommandService>();
builder.Services.AddScoped<IMentalStateExamCommandService, MentalStateExamCommandService>();
builder.Services.AddScoped<IMentalStateExamRepository, MentalStateExamRepository>();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
