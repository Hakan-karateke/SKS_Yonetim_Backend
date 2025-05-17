using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IKullaniciManager _kullaniciManager;
        private readonly IAdminManager _adminManager;

        public AdminController(IKullaniciManager kullaniciManager, IAdminManager adminManager)
        {
            _kullaniciManager = kullaniciManager;
            _adminManager = adminManager;
        }

        [Authorize(Roles = "1")]  // Sadece Admin rolü (1) silebilir
        [HttpDelete("DeleteKullanici/{id}")]
        public IActionResult DeleteKullanici(int id)
        {
            try
            {
                var result = _kullaniciManager.DeleteKullanici(id);
                if (result)
                {
                    return Ok(new { success = true, message = "Kullanıcı ve ilişkili tüm veriler başarıyla silindi." });
                }
                else
                {
                    return NotFound(new { success = false, message = "Kullanıcı bulunamadı veya silinemedi." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("GetDashboardData")]
        public IActionResult GetDashboardData()
        {
            try
            {
                var dashboardData = _adminManager.GetDashboardData();
                return Ok(dashboardData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("GetKullaniciByRol/{rol}")]
        public IActionResult GetKullaniciByRol(int rol)
        {
            try
            {
                var kullanicilar = _adminManager.GetKullaniciByRol(rol);
                return Ok(kullanicilar);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "0")]
        [HttpGet("GetLogList/{page}")]
        public IActionResult GetLogList(int page)
        {
            try
            {
                var logs = _adminManager.GetLogList(page);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                var result = _adminManager.ChangeAdminPassword(changePasswordModel);
                if (result)
                {
                    return Ok(new { success = true, message = "Şifre başarıyla değiştirildi." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Şifre değiştirme işlemi başarısız." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}