using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFinal.Service.Core;
using WebFinal.Service.Data;
using WebFinal.Service.Models;

namespace WebFinal.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;


        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public IActionResult Index()
        {
          var models = _categoryService.GetAll();

            return View(models);
        }

        public IActionResult Create()
        {           
            return View();
        }
        public IActionResult Edit(int id)
        {
            var model = _categoryService.GetById(id);
            return View(model);
        }


        public IActionResult Save(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Save(model);
                TempData["success"] = "Bilgiler Kaydedildi";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Hata oluştu";

            return View("Create", model);

        }

        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
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
