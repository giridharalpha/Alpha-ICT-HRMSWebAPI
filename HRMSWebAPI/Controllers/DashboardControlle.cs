using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMS.BusinessObjects.Models;
using HRMS.DAL.Context;
using HRMS.BLL;

namespace HRMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public DashboardService _dashboardService;
       
        public DashboardController(HRMSContext context)
        {
            _dashboardService = new DashboardService(context);  
        }       
        [HttpGet("{id}")]
        public ResultViewModel<DashboardViewModel> GetDashboardAllDetails(int id)
        {
            ResultViewModel<DashboardViewModel> objResult = _dashboardService.GetDashboardAllDetails(id);
            return objResult;
        }

        [HttpGet("GetAnniversaries/{id}")]      
        public ResultViewModel<List<WorkAnniversaryViewModel>> GetAnniversaries(int id)
        {
            ResultViewModel<List<WorkAnniversaryViewModel>> objResult =_dashboardService.GetAnniversaries(id);
            return objResult;
        }
        [HttpGet("GetBirthdays")]
        public ResultViewModel<List<BirthDayViewModel>> GetBirthdays()
        {
            ResultViewModel<List<BirthDayViewModel>> objResult =_dashboardService.GetBirthDays();
            return objResult;
        }
        [HttpGet("GetNewsAndEvents")]
        public ResultViewModel<List<NewsEventsViewModel>> GetNewsAndEvents()
        {
            ResultViewModel<List<NewsEventsViewModel>> objResult =_dashboardService.GetNewsAndEvents();
            return objResult;
        }
        [HttpGet("GetTodaysLeaves")]
        public ResultViewModel<List<LeavesViewModel>> GetTodaysLeaves()
        {
            ResultViewModel<List<LeavesViewModel>> objResult =_dashboardService.GetTodaysLeaves();
            return objResult;
        }
        [HttpGet("GetLeaveRequests/{id}")]
        public ResultViewModel<List<LeaveRequestsViewModel>> GetLeaveRequests(int id)
        {
            ResultViewModel<List<LeaveRequestsViewModel>> objResult =_dashboardService.GetLeaveRequests(id);
            return objResult;
        }
        [HttpGet("GetUpcommingHolidays")]
        public ResultViewModel<List<UpcommingHolidaysViewModel>> GetUpcommingHolidays()
        {
            ResultViewModel<List<UpcommingHolidaysViewModel>> objResult =_dashboardService.GetUpcommingHolidays();
            return objResult;
        }
        [HttpGet("GetDashboardCountSummary/{id}")]
        public ResultViewModel<DashboardCountsSummaryViewModel> GetDashboardCountSummary(int id)
        {
            ResultViewModel<DashboardCountsSummaryViewModel> objResult =_dashboardService.GetDashboardCountSummary(id);
            return objResult;
        }

    }
}
