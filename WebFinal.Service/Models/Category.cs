using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFinal.Service.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Kategori Adı:")]
        [Required (ErrorMessage ="Ad alanı zorunludur")]
        public string Name { get; set; }
        //belki sou işareti olabilir

        public virtual ICollection<Giyim>? Giyimler { get; set;}

       

        
    }
}
