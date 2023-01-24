using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRMS.BusinessObjects.Models
{
   public class HolidayMaster
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string HolidayName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime HolidayDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string HolidayType { get; set; }
       
    }
}
