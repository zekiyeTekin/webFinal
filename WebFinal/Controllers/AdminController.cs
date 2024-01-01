using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFinal.Service.Core;
using WebFinal.Service.Data;

namespace WebFinal.Controllers
{
    //[Authorize(Roles = "admin, manager")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        private readonly AdminService _adminService;


        public AdminController(AdminService adminService)
        {
            _adminService = adminService;

        }

        public IActionResult Index()
        {
            var models = _adminService.GetAll();
            return View(models);
        }
    }
}
