using NPTN.MongoDemo.Api.Extensions;
using NPTN.MongoDemo.Application;
using NPTN.MongoDemo.Infrastructure;
using NPTN.MongoDemo.Infrastructure.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(MongoDbSettings.SectionName));
builder.Services.Configure<MongoDbAtlasSettings>(builder.Configuration.GetSection(MongoDbAtlasSettings.SectionName));

builder.Services
    .AddHttpContextAccessor()
    .AddApplicationLayer()
    .AddInfrastructureLayer();

var app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler(new ExceptionHandlerOptions
    {
        ExceptionHandlingPath = "/error",
        AllowStatusCode404Response = true
    });
}

app.UseHttpsRedirection();

app.Run();
