using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestLiveCode.Business;
using TestLiveCode.Context;
using TestLiveCode.MapperProfile;
using TestLiveCode.Model;
using TestLiveCode.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyLocalhost", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContextExample>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllers()
       .AddJsonOptions(options =>
          options.JsonSerializerOptions
             .ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Services

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();

//Business

builder.Services.AddScoped<IClientBusiness, ClientBusiness>();
builder.Services.AddScoped<ITicketBusiness, TicketBusiness>();
builder.Services.AddScoped<IUserLoginBusiness, UserLoginBusiness>();


//Mapper

builder.Services.AddAutoMapper(typeof(MapperProfile));

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
app.UseCors("AllowAnyLocalhost");

app.UseAuthorization();
app.MapControllers();

app.Run();
