using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFinal.Service.ViewModel
{
    public class TakiViewModel
    {

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "Takı Adı")]
        public string TakiAd { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Price")]
        public int Price { get; set; }

       
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Takı Görseli")]
        public IFormFile ProfileImage { get; set; }

        public DateTime CreateDate { get; set; }
        = DateTime.Now;

    }
}
