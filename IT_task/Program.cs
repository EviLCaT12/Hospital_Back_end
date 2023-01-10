using domain.Logic;
using domain.Models;
using domain.UseCases;
using Microsoft.EntityFrameworkCore;
using DataBase;
using DataBase.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql($"Host=localhost;Port=5432;Database=db;Username=postgres;Password=2012xxx"));
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.EnableSensitiveDataLogging(true));
builder.Services.AddTransient<IUserRepository, UserRepo>();
builder.Services.AddTransient<ITimeTableRepository, TimeTableRepo>();
builder.Services.AddTransient<IVisitRepository, VisitRepo>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepo>();
builder.Services.AddTransient<ISpecRepository, SpecializationRepo>();
builder.Services.AddTransient<UserUseCases>();
builder.Services.AddTransient<DoctorUseCases>();
builder.Services.AddTransient<VisitUseCases>();
builder.Services.AddTransient<TimeTableUseCases>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();