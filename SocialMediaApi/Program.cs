using Business.Abstracts;
using Business.Concretes;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);


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
