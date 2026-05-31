using Asp.NetCore_Playlist.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore_Playlist.Controllers
{
    public class AuthController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [MyActionFilter]
        public IActionResult M1()
        {
            return View();
        }
    }
}
