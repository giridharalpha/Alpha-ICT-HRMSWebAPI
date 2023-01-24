using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessObjects.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]       
        public string Password { get; set; }

        [NotMapped]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
