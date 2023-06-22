using Bixbee.Data.Contexts;
using BixBee.Domain.Implementation;
using BixBee.Domain.Implementation.Authentication;
using BixBee.Domain.Interface;
using BixBee.Domain.Interface.IAuthentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EducationAppContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnectonString")
    ));
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IgenericService, GenericService>();
builder.Services.AddTransient<IinstitutionService, InstitutionService>();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();

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
