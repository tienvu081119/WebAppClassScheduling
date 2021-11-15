using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class ResetPassword
    {
        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
