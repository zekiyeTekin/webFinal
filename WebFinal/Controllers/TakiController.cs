using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using WebFinal.Service.Core;
using WebFinal.Service.Data;
using WebFinal.Service.ViewModel;
using WebFinal.Service.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebFinal.Controllers
{
    [Authorize]
    public class TakiController : Controller
    {
        

        private readonly AppDbContext _db;
        private readonly TakiService _takiService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public TakiController(AppDbContext db, IWebHostEnvironment hostEnvironment, TakiService takiService)
        {
            _db = db;
            webHostEnvironment = hostEnvironment;
            _takiService = takiService;
        }

        public async Task<IActionResult> Index()
        {
            var taki = await _db.Takiler.ToListAsync();
            return View(taki);

        }
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(TakiViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                var taki = new Taki
                {
                    TakiAd = model.TakiAd,
                    Description = model.Description,
                    Price = model.Price,
                    ProfileImagePath = uniqueFileName,
                };
                _db.Add(taki);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private string UploadedFile(TakiViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        public async Task<int> Delete(int id)
        {
            var taki = await _db.Takiler.FindAsync(id);
            if (taki != null)
            {
                string ExitingFile = Path.Combine(webHostEnvironment.WebRootPath, "images", taki.ProfileImagePath);
                System.IO.File.Delete(ExitingFile);
                _db.Takiler.Remove(taki);
                _db.SaveChanges();
            }

            return await _db.SaveChangesAsync();
        }






    }
}