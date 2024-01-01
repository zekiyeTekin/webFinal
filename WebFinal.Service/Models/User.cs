using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFinal.Service.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public bool Locked { get; set; } = false; //diğer zamanlarda kullanıcıyı silmek yerine pasife cekmek için
        public DateTime CreatedAd { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";




    }
}
