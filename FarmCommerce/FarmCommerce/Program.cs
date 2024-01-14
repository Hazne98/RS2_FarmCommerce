using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services;
using FarmCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IProizvodiService, ProizvodiService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IService<FarmCommerce.Model.Proizvodi,ProizvodSearchObject>, ProizvodiService>();
//builder.Services.AddTransient<IService<FarmCommerce.Model.Proizvodi>, BaseService<FarmCommerce.Model.Proizvodi, FarmCommerce.Services.Database.Proizvod>();
//NE TREBAMO DA PRAVIMO NI INTERFACE NI SERVICE, URADITI OVAKO ILI NAPRAVIT PRAZAN INTERFACE I SERVICE RADI DALJNJEG RAZVOJA

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Rs2farmCommerceContext>(options =>
 options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(IKorisniciService));

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
