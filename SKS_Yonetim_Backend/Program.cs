using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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
