using Api_RESTFul.Models;
using Api_RESTFul.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CONTROLADORES DE LA API:
builder.Services.AddControllers();

// DOCUMENTACION Swagger:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// INYECCION PARA USAR LO SECRETO EN TODO LUGAR:
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// INYECCION DE LA DB:
builder.Services.AddDbContext<MyDBcontext>(options => options.UseSqlServer(builder.Configuration["Cadena_Conexion"]));

// INYECCION DE LOS SERVICIOS PARA INTERACTUAR CON LA DB:
builder.Services.AddScoped<Servicios_TipoEstacionamiento>();
builder.Services.AddScoped<Servicios_AlquilerEstacionamiento>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
