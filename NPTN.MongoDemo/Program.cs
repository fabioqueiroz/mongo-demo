using NPTN.MongoDemo.Api.Endpoints;
using NPTN.MongoDemo.Api.Extensions;
using NPTN.MongoDemo.Application.Options;
using NPTN.MongoDemo.Application.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDatabase"));

builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/movies/{title}", async (string title, IMovieService movieService, CancellationToken cancellationToken) =>
{
    return await movieService.GetMovieByTitleAsync(title, cancellationToken); // "Back to the Future"
})
    .WithTags(EndpointTag.Movies)
    .WithName("GetMovieByTitle")
    .WithOpenApi();

app.Run();
