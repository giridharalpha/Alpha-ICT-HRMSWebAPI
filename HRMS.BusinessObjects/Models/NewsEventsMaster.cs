using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;
namespace HRMS.BusinessObjects.Models
{
    public class NewsEventsMaster
    {
        [Key]
        public int EventID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string EventName { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string EventDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EventDate { get; set; }
        [Column(TypeName = "bit")]
        public Boolean IsActive { get; set; }              
        [Column(TypeName = "int")]
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "int")]
        public int UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }

    }
}
