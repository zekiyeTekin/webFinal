using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Service.Data;
using WebFinal.Service.Models;

namespace WebFinal.Service.Core
{

    //TakiSeviceyi kullanmadımm


    public class TakiService
    {
        private readonly AppDbContext _db;

        public TakiService(AppDbContext db)
        {
            _db = db;

        }
        public async Task<List<Taki>> GetTakiler()
        {
            return await _db.Takiler.ToListAsync();
        }

        public async Task<Taki> GetTakiById(int id)
        {
            return await _db.Takiler.FindAsync(id);
        }

        public async Task<int> CreateTaki(Taki taki)
        {
            await _db.Takiler.AddAsync(taki);
            await _db.SaveChangesAsync();
            return taki.Id;
        }

        public async Task<int> UpdateTaki(Taki taki)
        {
            _db.Takiler.Update(taki);
            return await _db.SaveChangesAsync();
        }

        //public async Task<int> DeleteTaki(int id)
        //{
        //    var taki = await _db.Takiler.FindAsync(id);
        //    if (taki == null)
        //        return 0;

        //    _db.Takiler.Remove(taki);
        //    return await _db.SaveChangesAsync();
        //}
      



    }
}
