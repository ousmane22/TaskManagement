using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.DTO;
using AutoMapper;
using TaskManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Add services to the container.
builder.Services.AddDbContext<TaskManagementDbContext>(options => 
     options.UseSqlServer(builder.Configuration.GetConnectionString("TaskManagementConnectionString")));

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
