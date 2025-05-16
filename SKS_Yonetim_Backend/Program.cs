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
using Microsoft.OpenApi.Models;
using System.Reflection;

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
/*
    * Manager sınıflarını DI container'a ekleyelim.
 */
builder.Services.AddScoped<IRandevuManager, RandevuManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IKullaniciManager, KullaniciManager>();
builder.Services.AddScoped<IAdminManager, AdminManager>();

/*
 * Entity Repository Pattern için gerekli olan servisleri ekleyelim.
 * Bu servisler, veri erişim katmanını yönetecek.
 */ 
builder.Services.AddScoped<IKullaniciDal, KullaniciDal>();
builder.Services.AddScoped<IRandevuDal, RandevuDal>();
builder.Services.AddScoped<IRandevuTurDal, RandevuTurDal>();
builder.Services.AddScoped<IRandevuYeriDal, RandevuYeriDal>();
builder.Services.AddScoped<IRandevumDal, RandevumDal>();
builder.Services.AddScoped<IRandevuAlinanSaatDal, RandevuAlinanSaatDal>();
builder.Services.AddScoped<IRandevuAlinmayacakSaatDal, RandevuAlinmayacakSaatDal>();
builder.Services.AddScoped<IRandevuYetkilendirmeDal, RandevuYetkilendirmeDal>();
builder.Services.AddScoped<ILogDal, LogDal>(); // Replaced HataLogDal with the new comprehensive LogDal

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Enhanced Swagger configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SKS Yönetim API",
        Version = "v1",
        Description = "SKS Randevu ve Yönetim Sistemi için API",
        Contact = new OpenApiContact
        {
            Name = "SKS Yönetim",
            Email = "info@bingolsks.com",
        }
    });

    // JWT authentication için Swagger'a Bearer token desteği ekle
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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

// Configure Swagger UI with more options
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SKS Yönetim API v1");
        c.RoutePrefix = "swagger";
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        c.DefaultModelsExpandDepth(0);
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
