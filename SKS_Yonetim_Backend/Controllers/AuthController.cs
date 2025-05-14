using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.DtoViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace SKS_Yonetim_Backend.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class AuthController : ControllerBase
          {
                    private readonly IAuthManager _authManager;
                    public AuthController(IAuthManager authManager)
                    {
                              _authManager = authManager;
                    }

                    /// <summary>
                    /// Bu method login işlemi yapar ve token oluşturur.
                    /// Oluşturulan token cookie olarak eklenir.
                    /// </summary>
                    /// <param name="loginViewModel"></param>
                    /// <returns>duruma göre giriş başarılı başarısız mesajı döndürür</returns>
                    /// <exception cref="Exception"></exception>
                    [AllowAnonymous]
                    [HttpPost("GetToken")]
                    public IActionResult GetToken([FromBody] LoginViewModel loginViewModel)
                    {
                              try
                              {
                                        var result = _authManager.GetTokenModel(loginViewModel);
                                        if (result != null)
                                        {
                                                  string token = GenerateToken(result);
                                                  // Token'ı HttpOnly Cookie olarak ekliyoruz
                                                  var cookieOptions = new CookieOptions
                                                  {
                                                            HttpOnly = false, // Cookie'ye JS tarafından erişilebilir
                                                            Secure = true, //localde çalıştığımız için secure false, canlıda daha sonra true yapılacak
                                                            SameSite = SameSiteMode.None, // Cross-site isteklerinde de cookie gönderilir
                                                            Expires = DateTime.UtcNow.AddHours(1)
                                                  };

                                                  Response.Cookies.Append("Token", token, cookieOptions);

                                                  return Ok(new { message = "Giriş başarılı" });
                                        }

                                        return Ok(new { message = "Geçersiz kullanıcı adı veya şifre" });
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(new { error = ex.Message });
                              }

                    }

                    /// <summary>
                    /// Bu method gele dtokullanici modele göre token oluşturur.
                    /// </summary>
                    /// <param name="result"></param>
                    /// <returns>oluşturulan tokern(string) döndürülür</returns>
                    /// <exception cref="Exception"></exception>
                    private static string GenerateToken(TokenModel result)
                    {
                              try
                              {
                                        string securityKey = "nerde_kaldi_bu_bingolun_randevulari";
                                        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                                        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                                        List<Claim> claims = new List<Claim>
                                        {
                                                  new("Rol", result.Rol.ToString()),
                                                  new("Id", result.Id.ToString()),
                                                  new("Ad", result.Ad),
                                                  new("Soyad", result.Soyad),
                                                  new("Email", result.Email)
                                        };

                                        var token = new JwtSecurityToken(
                                                  issuer: "bingolsks.com",
                                                  audience: "bingolsks.com",
                                                  expires: DateTime.Now.AddHours(1),
                                                  signingCredentials: signingCredentials,
                                                  claims: claims
                                        );

                                        return new JwtSecurityTokenHandler().WriteToken(token);

                              }
                              catch (Exception ex)
                              {
                                        throw new Exception(ex.Message);
                              }
                    }

                    /// <summary>
                    /// Bu method çıkış yapıldığında çerezlerin temizlenmesini sağlar.
                    /// </summary>
                    /// <returns>string message</returns>
                    /// <exception cref="Exception"></exception>
                    [HttpPost("Logout")]
                    public IActionResult Logout()
                    {
                              try
                              {
                                        Response.Cookies.Delete("Token");
                                        return Ok(new { message = "Çıkış başarılı" });
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(new { error = ex.Message });
                              }


                    }
          }


}