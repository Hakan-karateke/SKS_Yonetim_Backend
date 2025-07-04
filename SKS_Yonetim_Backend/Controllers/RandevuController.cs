using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class RandevuController : ControllerBase
          {
                    private readonly IRandevuManager _randevuManager;

                    public RandevuController(IRandevuManager randevuManager)
                    {
                              _randevuManager = randevuManager;
                    }

                    [Authorize]
                    [HttpPost("CreateRandevuTur")]
                    public IActionResult CreateRandevuTur(RandevuTur randevuTur)
                    {
                              try
                              {
                                        var result = _randevuManager.CreateRandevuTur(randevuTur);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetDtoCalenderByRandevuId/{randevuId}")]
                    public IActionResult GetDtoCalenderByRandevuId(int randevuId)
                    {
                              try
                              {
                                        var result = _randevuManager.GetDtoCalenderByRandevuId(randevuId);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("UpdateRandevuTur")]
                    public IActionResult UpdateRandevuTur(RandevuTur randevuTur)
                    {
                              try
                              {
                                        var result = _randevuManager.UpdateRandevuTur(randevuTur);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpDelete("DeleteRandevuTur/{id}")]
                    public IActionResult DeleteRandevuTur(int id)
                    {
                              try
                              {
                                        var result = _randevuManager.DeleteRandevuTur(id);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetAllRandevuTur")]
                    public IActionResult GetAllRandevuTur()
                    {
                              try
                              {
                                        var result = _randevuManager.GetAllRandevuTur();
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetRandevuTurById/{id}")]
                    public IActionResult GetRandevuTurById(int id)
                    {
                              try
                              {
                                        var result = _randevuManager.GetRandevuTurById(id);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetRandevuByRandevuTurId/{randevuTurId}")]
                    public IActionResult GetRandevuByRandevuTurId(int randevuTurId)
                    {
                              try
                              {
                                        var result = _randevuManager.GetRandevuByRandevuTurId(randevuTurId);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetRandevuByKullaniciId/{kullaniciId}")]
                    public IActionResult GetRandevuByKullaniciId(int kullaniciId)
                    {
                              try
                              {
                                        var result = _randevuManager.GetRandevuByKullaniciId(kullaniciId);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpDelete("DeleteRandevuById/{id}")]
                    public IActionResult DeleteRandevuById(int id)
                    {
                              try
                              {
                                        var result = _randevuManager.DeleteRandevuById(id);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("UpdateRandevu")]
                    public IActionResult UpdateRandevu(Randevu randevu)
                    {
                              try
                              {
                                        var result = _randevuManager.UpdateRandevu(randevu);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetAllRandevu")]
                    public IActionResult GetAllRandevu()
                    {
                              try
                              {
                                        var result = _randevuManager.GetAllRandevu();
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpPost("CreateOrUpdateRandevuWithCalender")]
                    public IActionResult CreateOrUpdateRandevuWithCalender(DtoCalender randevu)
                    {
                              try
                              {
                                        var result = _randevuManager.CreateOrUpdateRandevuWithCalender(randevu);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpPut("UpdateRandevuYeri")]
                    public IActionResult UpdateRandevuYeri(RandevuYeri randevuYeri)
                    {
                              try
                              {
                                        var result = _randevuManager.UpdateRandevuYeri(randevuYeri);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }
                    [Authorize]
                    [HttpDelete("DeleteRandevuYeri/{id}")]
                    public IActionResult DeleteRandevuYeri(int id)
                    {
                              try
                              {
                                        var result = _randevuManager.DeleteRandevuYeri(id);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetRandevuYeriById/{id}")]
                    public IActionResult GetRandevuYeriById(int id)
                    {
                              try
                              {
                                        var result = _randevuManager.GetRandevuYeriById(id);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetAllRandevuYeri")]
                    public IActionResult GetAllRandevuYeri()
                    {
                              try
                              {
                                        var result = _randevuManager.GetAllRandevuYeri();
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpPost("CreateRandevuYeri")]
                    public IActionResult CreateRandevuYeri(RandevuYeri randevuYeri)
                    {
                              try
                              {
                                        var result = _randevuManager.CreateRandevuYeri(randevuYeri);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }

                    [Authorize]
                    [HttpGet("GetRandevuTarihleriByRandevuIdandDate")]
                    public IActionResult GetRandevuTarihleriByRandevuIdandDate(int randevuId, DateTime date)
                    {
                              try
                              {
                                        var result = _randevuManager.GetRandevuTarihleriByRandevuIdandDate(randevuId, date);
                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(ex.Message);
                              }
                    }


          }
}