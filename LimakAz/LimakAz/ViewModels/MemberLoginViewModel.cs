using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class MemberLoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
