using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Account
    {
        [Key]
        public string NIK            { get; set; }
        [Required]
        public string Password       { get; set; }

        public DateTime ExipiredTime { get; set; }

        public string OTP            { get; set; }

        public bool IsActive         { get; set; }

        public Employee Employee     { get; set; }

        public Profiling Profiling   { get; set; }

        public ICollection<AccountRole> AccountRole { get; set; }
    }
}
