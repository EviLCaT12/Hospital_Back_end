using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Logic;
using domain.Models;
using domain.UseCases;
using Microsoft.EntityFrameworkCore;
using DataBase;
using DataBase.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql($"Host=localhost;Port=5432;Database=db;Username=postgres;Password=2012xxx"));
builder.Services.AddTransient<IUserRepository, UserRepo>();