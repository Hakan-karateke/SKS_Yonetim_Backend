using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IRandevuManager _randevuManager;
        private readonly IKullaniciManager _kullaniciManager;

        public KullaniciController(IRandevuManager randevuManager, IKullaniciManager kullaniciManager)
        {
            _randevuManager = randevuManager;
            _kullaniciManager = kullaniciManager;
        }

        [Authorize]
        [HttpGet("GetKullaniciById/{id}")]
        public IActionResult GetKullaniciById(int id)
        {
            try
            {
                var result = _kullaniciManager.GetKullaniciById(id);
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
        [HttpPost("UpdateKullanici")]
        public IActionResult UpdateKullanici([FromBody] Kullanici kullanici)
        {
            try
            {
                var result = _kullaniciManager.UpdateKullanici(kullanici);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "3")] // Sadece Kullanıcı rolü (3)
        [HttpPost("CreateRandevum")]
        public IActionResult CreateRandevum(Randevum randevum)
        {
            try
            {
                var result = _kullaniciManager.CreateRandevum(randevum);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Randevu oluşturulamadı.", error = ex.Message });
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("GetKullaniciRandevum/{kullaniciId}")]
        public IActionResult GetKullaniciRandevum(int kullaniciId)
        {
            try
            {
                var randevular = _kullaniciManager.GetKullaniciRandevum(kullaniciId);
                return Ok(randevular);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "3")]
        [HttpDelete("DeleteRandevum/{id}")]
        public IActionResult DeleteRandevum(int id)
        {
            try
            {
                var result = _kullaniciManager.DeleteRandevum(id);
                if (result)
                {
                    return Ok(new { success = true, message = "Randevu başarıyla silindi." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Randevu silinirken bir hata oluştu." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("GetAvailableRandevular")]
        public IActionResult GetAvailableRandevular()
        {
            try
            {
                var availableRandevular = _randevuManager.GetAllRandevu()
                    .Where(r => r.OnayDurumu == IslemTip.Onaylandi.GetHashCode())
                    .ToList();

                return Ok(availableRandevular);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("GetRandevuDetails/{randevuId}")]
        public IActionResult GetRandevuDetails(int randevuId)
        {
            try
            {
                // Randevu detaylarını al
                var randevu = _randevuManager.GetAllRandevu()
                    .FirstOrDefault(r => r.Id == randevuId);

                if (randevu == null)
                {
                    return NotFound(new { success = false, message = "Randevu bulunamadı." });
                }

                // Randevu türü detaylarını al
                var randevuTur = _randevuManager.GetRandevuTurById(randevu.RandevuTurId);

                // Tüm bilgileri birleştirerek döndür
                var randevuDetail = new
                {
                    Randevu = randevu,
                    RandevuTur = randevuTur
                };

                return Ok(randevuDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}