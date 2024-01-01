using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFinal.Service.Models
{
    public class GiyimDTO
    {

        public int Id { get; set; }


        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Kategori alanı zorunludur")]
        public int CategoryId { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public string Name { get; set; }

        [DisplayName("Tur")]
        [Required(ErrorMessage = "Tür alanı zorunludur")]
        public string Tur { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı zorunludur")]
        public string Gender { get; set; }

        public string? CategoryName { get; set; }

        public List<Category>? CategoryList { get; set; } 


    }
}
