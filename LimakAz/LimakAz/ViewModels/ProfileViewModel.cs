using LimakAz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class ProfileViewModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "Ad,Soyad minimum 6 və maksimum 50 uzunluqda ola bilər")]
        public string FullName { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "İstifadəçi adı minimum 6 və maksimum 30 uzunluqda ola bilər")]
        public string UserName { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Email minimum 8 və maksimum 100 uzunluqda ola bilər")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 8)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Şifrə minimum 6 və maksimum 20 uzunluqda ola bilər")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Şifrə minimum 6 və maksimum 20 uzunluqda ola bilər")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Şifrə minimum 6 və maksimum 20 uzunluqda ola bilər")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Date)]

        public DateTime BirthDay { get; set; }

        public int WareHouseId { get; set; }
    }
}
