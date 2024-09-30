using NPTN.MongoDemo.Api.Endpoints;
using NPTN.MongoDemo.Api.Extensions;
using NPTN.MongoDemo.Application;
using NPTN.MongoDemo.Application.Options;
using NPTN.MongoDemo.Application.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(MongoDbSettings.SectionName));

builder.Services.AddApplicationLayer();

var app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
