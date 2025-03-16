using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class KullaniciController : ControllerBase
          {
                    private readonly IKullaniciManager _kullaniciManager;

                    public KullaniciController(IKullaniciManager kullaniciManager)
                    {
                              _kullaniciManager = kullaniciManager;
                    }


                    [Authorize]
                    [HttpGet("GetDtoProfilModelById/{id}")]
                    public IActionResult GetDtoProfilModelById(int id)
                    {
                              try
                              {
                                        var result = _kullaniciManager.GetDtoProfilModelById(id);
                                        if (result is null)
                                        {
                                                  return NotFound();
                                        }
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpPost("ChangePassword")]
                    public IActionResult ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
                    {
                              try
                              {
                                        var result = _kullaniciManager.ChangePassword(changePasswordModel);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpPost("UpdateProfil")]
                    public IActionResult UpdateProfil([FromBody] DtoProfilModel dtoProfilModel)
                    {
                              try
                              {
                                        var result = _kullaniciManager.UpdateProfil(dtoProfilModel);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }
          }
}