using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRMS.BusinessObjects.Models
{
    public class DesignationMaster
    {
        [Key]
        public int DesignationID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string DesignationName { get; set; }
       
    }
}
