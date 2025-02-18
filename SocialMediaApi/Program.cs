using Business.Abstracts;
using Business.Concretes;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SocialMediaContext> (options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Container
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<SocialMediaContext>();
#endregion 


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
