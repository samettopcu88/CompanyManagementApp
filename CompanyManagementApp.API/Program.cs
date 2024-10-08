using CompanyManagementApp.DAL.Context;
using CompanyManagementApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext konfigürasyonu
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity servisleri
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // Parola kuralları
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<AppDbContext>() // Identity için AppDbContext kullanılıyor
.AddDefaultTokenProviders();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper konfigürasyonu

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication ve Authorization middleware'lerini ekleyin
app.UseAuthentication(); // Kimlik doğrulama
app.UseAuthorization();  // Yetkilendirme

app.MapControllers();

app.Run();
