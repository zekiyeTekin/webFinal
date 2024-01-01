using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFinal.Service.Core;
using WebFinal.Service.Data;
using WebFinal.Service.Models;

namespace WebFinal.Controllers
{
    
    public class GiyimController : Controller
    {
        private readonly GiyimService _giyimService;
       

        public GiyimController(GiyimService giyimService)
        {
            _giyimService = giyimService;
           
        }

        [Authorize]
        public IActionResult Index()
        {
          var models = _giyimService.GetAll();

            return View(models);
        }

        public IActionResult Create()
        {
            var viewModel = _giyimService.GetCreateViewModel();
            return View(viewModel);
        }
        public IActionResult Edit(int id)
        {
            var model = _giyimService.GetEditViewModel(id);
            return View(model);
        }


        public IActionResult Save(GiyimDTO viewmodel)
        {
           
            if (ModelState.IsValid)
            {
                _giyimService.Save(viewmodel);
                TempData["success"] = "Bilgiler Kaydedildi";

                return RedirectToAction("Index");
            }
            TempData["error"] = "Hata oluştu";
            return View("Edit", viewmodel);

        }

        public IActionResult Delete(int id)
        {
            try
            {
                _giyimService.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Bir Hata Oluştu";
                return RedirectToAction("Index");
            }
            TempData["success"] = "Kayıt Silindi";
            return RedirectToAction("Index");




        }


    }
}
