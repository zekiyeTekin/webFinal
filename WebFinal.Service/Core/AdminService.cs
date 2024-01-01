using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Service.Data;
using WebFinal.Service.Models;

namespace WebFinal.Service.Core
{
    public class AdminService
    {
        private readonly AppDbContext _db;


        public AdminService(AppDbContext db)
        {
            _db = db;

        }
        public User GetById(Guid id)
        {
            return _db.Users.First(p => p.Id == id);
        }
        public List<User> GetAll()
        {
            var models = _db.Users.ToList();
            return models;
        }

       
    }
}
