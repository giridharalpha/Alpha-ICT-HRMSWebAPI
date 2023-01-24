using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRMS.BusinessObjects.Models
{
    public class LeaveApplication
    {
        [Key]
        public int LeaveApplicationID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ApplicationDate { get; set; }
        [Column(TypeName = "int")]
        public int EmployeeID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FromDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ToDate { get; set; }
        [Column(TypeName = "int")]
        public int TotalDays { get; set; }
        [Column(TypeName = "int")]
        public int LeaveReasonID { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Comment { get; set; }
        [Column(TypeName = "int")]
        public int FinalLeaveStatusID { get; set; }
        [Column(TypeName = "int")]
        public int AssignForApprovalIDs { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserId")]
        [Column(TypeName = "int")]
        public int UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
    }
    enum LeaveStatus
    {
        

    }

}
