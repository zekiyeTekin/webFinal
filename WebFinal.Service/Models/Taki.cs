using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFinal.Service.Models
{
    public class Taki
    {

        public int Id { get; set; }
        public string TakiAd { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public string ProfileImagePath { get; set; }

        [NotMapped]
        public IFormFile ProfileImage { get; set; }

        public DateTime CreateDate { get; set; }
        = DateTime.Now;

    }
}
