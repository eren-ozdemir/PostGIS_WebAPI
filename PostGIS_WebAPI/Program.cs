using Microsoft.EntityFrameworkCore;
using PostGIS_WebAPI.BUSINESS.Abstract;
using PostGIS_WebAPI.BUSINESS.Concrete;
using PostGIS_WebAPI.REPOSITORIES.Abstract;
using PostGIS_WebAPI.REPOSITORIES.Concrete;
using PostGIS_WebAPI.REPOSITORIES.Context;
using NetTopologySuite.IO.Converters;
using PostGIS_WebAPI.ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = new LowerCaseNamingPolicy();
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory()); //Makes actions can accept geojson objects as paramater
   
});
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CityContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("City"),
        x => x.UseNetTopologySuite()
        )
    .UseLowerCaseNamingConvention();
});

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());
app.UseAuthorization();

app.MapControllers();

app.Run();
