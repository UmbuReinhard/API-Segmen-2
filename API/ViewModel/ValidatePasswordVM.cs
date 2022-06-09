using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class ValidatePasswordVM
    {

        public string Email { get; set; }

        public string Password { get; set; }
        public string OTP { get; set; }

        public string ValidateNewPassword { get; set; }

    }
}
