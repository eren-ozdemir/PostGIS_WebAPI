using Microsoft.EntityFrameworkCore;
using PostGIS_WebAPI.BUSINESS.Abstract;
using PostGIS_WebAPI.BUSINESS.Concrete;
using PostGIS_WebAPI.ENTITIES.Entities;
using PostGIS_WebAPI.REPOSITORIES.Abstract;
using PostGIS_WebAPI.REPOSITORIES.Concrete;
using PostGIS_WebAPI.REPOSITORIES.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CityContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("City"),
        x => x.UseNetTopologySuite()
        ).UseLowerCaseNamingConvention();
});

builder.Services.AddTransient<IGenericRepository<Building>, GenericRepository<Building>>();
builder.Services.AddTransient<IGenericService<Building>, GenericManager<Building>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
