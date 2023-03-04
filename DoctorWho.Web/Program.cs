using DoctorWho.Db;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Repositories;
using DoctorWho.Db.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
.AddNewtonsoftJson()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
})
.AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<DoctorRepository>();
builder.Services.AddScoped<EpisodeRepository>();

builder.Services.AddScoped<IValidator<Doctor>, DoctorValidator>();
builder.Services.AddScoped<IValidator<Episode>, EpisodeValidator>();

builder.Services.AddDbContext<DoctorWhoCoreDbContext>(
    dbcontextOptions => dbcontextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:DoctorWhoDbConnectionString"]
        ));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
