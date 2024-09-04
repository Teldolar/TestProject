using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TestDB;
using TestDB.Managers;
using TestServer.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextPool<TestDBContext>(
   options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<DoctorDbManager>();
builder.Services.AddTransient<PatientDbManager>();
builder.Services.AddTransient<DoctorManager>();
builder.Services.AddTransient<PatientManager>();
builder.Services.AddControllers();
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
app.UseDeveloperExceptionPage();

app.UseRouting();
app.MapControllers();

app.Run();
