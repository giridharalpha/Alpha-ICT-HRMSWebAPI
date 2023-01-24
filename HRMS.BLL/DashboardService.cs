using System;
using HRMS.BusinessObjects.Models;
using System.Linq;
using System.Threading.Tasks;
using HRMS.DAL.Repositories;
using HRMS.DAL.Context;
using System.Collections.Generic;
namespace HRMS.BLL
{
    public class DashboardService
    {
        private DashboardRepository objDashboardRepository;
        public DashboardService(HRMSContext context)
        {
            objDashboardRepository = new DashboardRepository(context);
        }
        public ResultViewModel<DashboardViewModel> GetDashboardAllDetails(int id)
        {
            try
            {
                if (id < 0)
                {
                    return new ResultViewModel<DashboardViewModel>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "User ID can not be less than 0" };
                }
                DashboardViewModel objDashboardAllDetails = objDashboardRepository.GetDashboardAllDetails(id);
                if (objDashboardAllDetails == null)
                {
                    return new ResultViewModel<DashboardViewModel>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<DashboardViewModel>() { Result = objDashboardAllDetails, ResponseCode = System.Net.HttpStatusCode.OK, Message =Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<DashboardViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }


        }
        public ResultViewModel<List<WorkAnniversaryViewModel>> GetAnniversaries(int id)
        {
            try
            {
                if (id < 0)
                {
                    return new ResultViewModel<List<WorkAnniversaryViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "User ID can not be less than 0" };
                }
                List<WorkAnniversaryViewModel> objResponse = objDashboardRepository.GetWorkAnniversaries(id);
                if (objResponse == null)
                {
                    return new ResultViewModel<List<WorkAnniversaryViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<List<WorkAnniversaryViewModel>>() { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<WorkAnniversaryViewModel>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }

        }
        public ResultViewModel<List<BirthDayViewModel>> GetBirthDays()
        {
            try
            {
                List<BirthDayViewModel> objResponse = objDashboardRepository.GetBirthdays();
                if (objResponse == null)
                {
                    return new ResultViewModel<List<BirthDayViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<List<BirthDayViewModel>>() { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<BirthDayViewModel>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }

        }
        public ResultViewModel<List<NewsEventsViewModel>> GetNewsAndEvents()
        {
            try
            {

                List<NewsEventsViewModel> objResponse = objDashboardRepository.GetNewsAndEvents();
                if (objResponse == null)
                {
                    return new ResultViewModel<List<NewsEventsViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage};
                }
                else
                {
                    return new ResultViewModel<List<NewsEventsViewModel>>() { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<NewsEventsViewModel>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }

        }
        public ResultViewModel<List<LeavesViewModel>> GetTodaysLeaves()
        {
            try
            {
                List<LeavesViewModel> objResponse = objDashboardRepository.GetTodaysLeaves();
                if (objResponse == null)
                {
                    return new ResultViewModel<List<LeavesViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<List<LeavesViewModel>>() { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<LeavesViewModel>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }

        }

        public ResultViewModel<List<LeaveRequestsViewModel>> GetLeaveRequests(int id)
        {
            try
            {
                if (id < 0)
                {
                    return new ResultViewModel<List<LeaveRequestsViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "User ID can not be less than 0" };
                }
                List<LeaveRequestsViewModel> objResponse = objDashboardRepository.GetLeaveRequests(id);
                if (objResponse == null)
                {
                    return new ResultViewModel<List<LeaveRequestsViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<List<LeaveRequestsViewModel>>() { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success};
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<LeaveRequestsViewModel>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }


        }
        public ResultViewModel<List<UpcommingHolidaysViewModel>> GetUpcommingHolidays()
        {
            try
            {

                List<UpcommingHolidaysViewModel> objResponse = objDashboardRepository.GetUpcommingHolidays();
                if (objResponse == null)
                {
                    return new ResultViewModel<List<UpcommingHolidaysViewModel>>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<List<UpcommingHolidaysViewModel>>() { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<UpcommingHolidaysViewModel>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }
        }
        public ResultViewModel<DashboardCountsSummaryViewModel> GetDashboardCountSummary(int UserID)
        {

            try
            {
                DashboardCountsSummaryViewModel objResponse = objDashboardRepository.GetDashboardCountSummary(UserID);
                if (objResponse == null)
                {
                    return new ResultViewModel<DashboardCountsSummaryViewModel>() { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<DashboardCountsSummaryViewModel>() { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message=Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<DashboardCountsSummaryViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }

        }
    }
}
