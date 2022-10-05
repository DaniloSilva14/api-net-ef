using FilmesAPI.Data;
using FilmesAPI.Services;
using FilmesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding connection DB
builder.Services.AddDbContext<AppDbContext>(opts => 
    opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("FilmeConnection"), new MySqlServerVersion(new Version(8, 0)))
);

// Adding automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adding services
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IGerenteService, GerenteService>();
builder.Services.AddScoped<ISessaoService, SessaoService>();

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
