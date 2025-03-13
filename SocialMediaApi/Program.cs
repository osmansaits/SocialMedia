using Business.Abstracts;
using Business.Concretes;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Utilities;

var builder = WebApplication.CreateBuilder(args);

// DBContext ve diðer servisler
builder.Services.AddDbContext<SocialMediaContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));

// API controller
builder.Services.AddControllers();

// Swagger API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// IoC Container servisleri
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<SocialMediaContext>();
builder.Services.AddScoped<IJwtService, JwtManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
