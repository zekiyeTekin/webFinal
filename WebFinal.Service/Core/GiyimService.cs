using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Service.Data;
using WebFinal.Service.Models;

namespace WebFinal.Service.Models
{
    public class GiyimService
    {
        private readonly AppDbContext _db;


        public GiyimService(AppDbContext db)
        {
            _db = db;

        }

        public GiyimDTO GetCreateViewModel()
        {
            var dto= new GiyimDTO();
            dto.CategoryList = _db.Categories.ToList();
            return dto;
        }
        //public GiyimDTO GetEditViewModel()
        //{
        //    var dto = GetCreateViewModel();
        //    return dto;
        //}



        public GiyimDTO GetEditViewModel(int id)
        {
            var model = _db.Giyimler.First(p => p.Id == id);
            var dto = new GiyimDTO
            {
                Id = model.Id,
                Name = model.Name,
                Tur = model.Tur,
                Gender = model.Gender,
                CategoryId = model.CategoryId,
               
            };
            dto.CategoryList = _db.Categories.ToList();
            return dto;
        }
        public List<GiyimDTO> GetAll()
        {
            var models = _db.Giyimler.Include(p=>p.Category).ToList();
            var dtoList=new List<GiyimDTO>();
            foreach (var model in models)
            {
                var dto = new GiyimDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    Tur = model.Tur,
                    Gender = model.Gender,
                    CategoryId = model.CategoryId,
                    CategoryName= model.Category.Name
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public void Save(GiyimDTO dto)
        {


            if (dto.Id == 0)
            {
                var model = new Giyim
                {
                    CategoryId = dto.CategoryId,
                    Name = dto.Name,
                    Tur = dto.Tur,
                    Gender = dto.Gender,
                };
                _db.Giyimler.Add(model);
            }
            else
            {
                var model = _db.Giyimler.Find(dto.Id);
                model.Name = dto.Name;
                model.Tur = dto.Tur;
                model.Gender = dto.Gender;
                model.CategoryId = dto.CategoryId;
                _db.Giyimler.Update(model);
            }

            _db.SaveChanges();

        }
        public void Delete(int id)
        {
            var model = _db.Giyimler.Find(id);
            _db.Giyimler.Remove(model);
            _db.SaveChanges();

        }

    }
}
