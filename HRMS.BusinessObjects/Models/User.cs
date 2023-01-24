using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.BusinessObjects.Models
{
   public  class User
    {
        [Key]
        public int UserID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Password { get; set; }
        [Column(TypeName = "int")]
        public int RoleID { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
