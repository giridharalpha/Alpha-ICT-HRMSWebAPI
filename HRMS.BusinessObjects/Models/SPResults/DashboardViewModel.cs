using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessObjects.Models
{
    public class DashboardViewModel
    {
        public List<WorkAnniversaryViewModel> todaysWorkAnniversary { get; set; }
        public List<BirthDayViewModel> todaysBirthDays { get; set; }
        public List<NewsEventsViewModel> todaysNewsEvents { get; set; }
        public List<LeavesViewModel> todaysLeaves { get; set; }
        public List<LeaveRequestsViewModel> leaveRequests { get; set; }
        public List<UpcommingHolidaysViewModel> upcommingHolidays { get; set; }
        public DashboardCountsSummaryViewModel dashboardCountsSummary { get; set; }
    }
    public class WorkAnniversaryViewModel
    {
        public string EmployeeName { get; set; }
        public string PhotoPath { get; set; }
        public string Designation { get; set; }
        public int YearsCompleted { get; set; }
    }
    public class BirthDayViewModel
    {
        public string EmployeeName { get; set; }
        public string PhotoPath { get; set; }
        public string Designation { get; set; }

    }
   
    public class NewsEventsViewModel
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public DateTime EventDate { get; set; }

    }
    public class LeavesViewModel
    {
        public string EmployeeName { get; set; }
        public string PhotoPath { get; set; }
        public string LeaveCount { get; set; }//half or 1 or 2 or more
        public string Description { get; set; }
    }
    public class LeaveRequestsViewModel
    {
        public string EmployeeName { get; set; }
        public string PhotoPath { get; set; }
        public string Designation { get; set; }
        public string Duration { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Approval1Name { get; set; }
        public string Approval1Status { get; set; }
        public string Approval2Name { get; set; }
        public string Approval2Status { get; set; }
        public string Approval3Name { get; set; }
        public string Approval3Status { get; set; }


    }
    public class UpcommingHolidaysViewModel
    {
        public string HolidayName { get; set; }
        public DateTime HolidayDate { get; set; }
        public string HolidayType { get; set; }        
    }
    public class DashboardCountsSummaryViewModel
    {
        public int TotalLeaves { get; set; }
        public int UsedLeaves { get; set; }
        public int LeaveBalnce { get; set; }
        public int WorkAnniversaryCount { get; set; }
        public int BirthDayCount { get; set; }
        public int EventsCount { get; set; }
        public int TodaysLeavesCount { get; set; }
    }
}
