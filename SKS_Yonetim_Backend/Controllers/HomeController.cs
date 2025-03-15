using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SKS_Yonetim_Backend.Controllers
{
          [ApiController]
          [Route("/")]
          public class HomeController : ControllerBase
          {
                    [AllowAnonymous]
                    [HttpGet]
                    public IActionResult Get()
                    {
                              return Ok("Welcome to SKS Yönetim Backend!");
                    }
          }
}