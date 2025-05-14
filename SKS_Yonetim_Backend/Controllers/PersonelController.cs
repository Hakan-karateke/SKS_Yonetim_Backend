using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IRandevuManager _randevuManager;

        public PersonelController(IRandevuManager randevuManager)
        {
            _randevuManager = randevuManager;
        }

        [Authorize(Roles = "2")] // Sadece Personel rolü (2)
        [HttpGet("GetPersonelDashboardData/{personelId}")]
        public IActionResult GetPersonelDashboardData(int personelId)
        {
            try
            {
                var dashboardData = _randevuManager.GetPersonelDashboardData(personelId);
                return Ok(dashboardData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost("CreateRandevu")]
        public IActionResult CreateRandevu(Randevu randevu)
        {
            try
            {
                var result = _randevuManager.CreateRandevu(randevu);
                if (result)
                {
                    return Ok(new { success = true, message = "Randevu başarıyla oluşturuldu." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Randevu oluşturulamadı." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost("CreateRandevuYeri")]
        public IActionResult CreateRandevuYeri(RandevuYeri randevuYeri)
        {
            try
            {
                var result = _randevuManager.CreateRandevuYeri(randevuYeri);
                if (result)
                {
                    return Ok(new { success = true, message = "Randevu yeri başarıyla oluşturuldu." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Randevu yeri oluşturulamadı." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "2")]
        [HttpGet("GetPersonelRandevuList/{personelId}")]
        public IActionResult GetPersonelRandevuList(int personelId)
        {
            try
            {
                var randevular = _randevuManager.GetRandevuByCreatedPersonelId(personelId);
                return Ok(randevular);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        
        [Authorize(Roles = "2")]
        [HttpPut("UpdateRandevu")]
        public IActionResult UpdateRandevu(Randevu randevu)
        {
            try
            {
                var result = _randevuManager.UpdateRandevu(randevu);
                if (result)
                {
                    return Ok(new { success = true, message = "Randevu başarıyla güncellendi." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Randevu güncellenemedi." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}