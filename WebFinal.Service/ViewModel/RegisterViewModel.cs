using System.ComponentModel.DataAnnotations;

namespace WebFinal.Service.ViewModel
{
    public class RegisterViewModel
    {
        //[Display(Name ="KullanıcıAdı", Prompt ="placeholder")]
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur!")]
        [StringLength(30, ErrorMessage = "Kullanıcı Adı alanına max 30 karakter girebilirsiniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Mail alanı zorunludur!")]
        [StringLength(30, ErrorMessage = "E-Mail alanına max 30 karakter girebilirsiniz!")]
        public string Mail { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [MinLength(6, ErrorMessage = "Şifre alanına min 6 karakter girebilirsiniz!")]
        [MaxLength(15, ErrorMessage = "Şifre alanına max 15 karakter girebilirsiniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı alanı zorunludur!")]
        [MinLength(6, ErrorMessage = "Şifre tekrarı alanına min 6 karakter girebilirsiniz!")]
        [MaxLength(15, ErrorMessage = "Şifre tekrarı alanına max 15 karakter girebilirsiniz!")]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }

}
