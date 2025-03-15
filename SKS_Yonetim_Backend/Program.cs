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

// CORS yapılandırmasını ekleyelim (Tüm kaynaklara izin ver)
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")  // Explicitly allow this origin
                  .AllowAnyHeader()  // Allow any header
                  .AllowAnyMethod()  // Allow any HTTP method
                  .AllowCredentials();  // Allow credentials
        });
});

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
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "bingolsks.com",
            ValidAudience = "bingolsks.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nerde_kaldi_bu_bingolun_randevulari"))
        };
    });

builder.Services.AddAuthorization();

// Add DbContext
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

// Middleware sırası önemli! CORS'u erkenden ekleyin.
app.UseCors("MyPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
