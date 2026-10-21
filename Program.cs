using FinalAPISession.Data;
using FinalAPISession.Helper;
using FinalAPISession.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

////Connection

///First way to connect to database

//var connection = builder.Configuration.GetConnectionString("x");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

//Second way to connect to database

builder.Services.AddDbContext<AppDbContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("x"))
);


//Repo
builder.Services.AddScoped(typeof(IGeneric<>), typeof(Generic<>));
builder.Services.AddScoped<DoctorRepo>();
builder.Services.AddScoped<PatientRepo>();


//Auto Mapping
builder.Services.AddAutoMapper(typeof(ProfileMapping));

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
