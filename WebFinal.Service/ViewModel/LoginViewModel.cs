using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFinal.Service.ViewModel
{
    public class LoginViewModel
    {
        //[Display(Name ="KullanıcıAdı", Prompt ="placeholder")]
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur!")]
        [StringLength(30, ErrorMessage = "Kullanıcı Adı alanına max 30 karakter girebilirsiniz!")]
        public string UserName { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [MinLength(6, ErrorMessage = "Şifre alanına min 6 karakter girebilirsiniz!")]
        [MaxLength(15, ErrorMessage = "Şifre alanına max 15 karakter girebilirsiniz!")]
        public string Password { get; set; }
    }

}
