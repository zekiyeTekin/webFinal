using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFinal.Service.Models
{
    public class Giyim
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Tur { get; set; }

        public string Gender { get; set; } 


        public DateTime CreateDate { get; set; }
        = DateTime.Now;

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        //public string CategoryName { get; internal set; }
    }
}
