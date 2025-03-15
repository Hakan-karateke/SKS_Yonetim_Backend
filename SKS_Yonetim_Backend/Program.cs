using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SKS_Yonetim_Backend.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Managers;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.EntityReporsitory;

var builder = WebApplication.CreateBuilder(args);

// Servisleri DI container'a kaydetme
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddScoped<IKullaniciDal, KullaniciDal>();
builder.Services.AddScoped<IOgretmenDal, OgretmenDal>();
builder.Services.AddScoped<IOgrenciDal, OgrenciDal>();
builder.Services.AddScoped<IPersonelDal, PersonelDal>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT Authentication Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // Geliştirme ortamında HTTPS zorunlu değil
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "bingolsks.com",  // AuthController'daki issuer ile aynı olmalı
            ValidAudience = "bingolsks.com", // AuthController'daki audience ile aynı olmalı
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nerde_kaldi_bu_bingolun_randevulari"))
        };
    });

builder.Services.AddAuthorization();

// Add DbContext with SQL Server connection based on the OS platform
builder.Services.AddDbContext<SKSDbContext>((serviceProvider, options) =>
{
    if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
    {
        options.UseSqlServer("server=localhost; database=SKSRandevuDB; User Id=SA; password=reallyStrongPwd123; TrustServerCertificate=True;");
    }
    else
    {
        options.UseSqlServer("Server=.;Database=SKSRandevuDB;Trusted_Connection=SSPI;TrustServerCertificate=true;");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware sırası önemli! Authentication önce çağrılmalı.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
