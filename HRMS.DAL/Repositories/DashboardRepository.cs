using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessObjects.Models;
using HRMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
namespace HRMS.DAL.Repositories
{
    public class DashboardRepository
    {
        public readonly HRMSContext _context;
        public DashboardRepository(HRMSContext context)
        {
            _context = context;
        }
        public DashboardViewModel GetDashboardAllDetails(int userID)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                DashboardViewModel objDashboardViewModel = new DashboardViewModel();
                using (var multi = objDBConnection.connection.QueryMultiple("[dbo].[GetDetailsForDashboard]", new { @UserID = userID }, commandType: CommandType.StoredProcedure))
                {
                    objDashboardViewModel.todaysWorkAnniversary = multi.Read<WorkAnniversaryViewModel>().ToList();
                    objDashboardViewModel.todaysBirthDays = multi.Read<BirthDayViewModel>().ToList();
                    objDashboardViewModel.todaysNewsEvents = multi.Read<NewsEventsViewModel>().ToList();
                    objDashboardViewModel.todaysLeaves = multi.Read<LeavesViewModel>().ToList();
                    objDashboardViewModel.leaveRequests = multi.Read<LeaveRequestsViewModel>().ToList();
                    objDashboardViewModel.upcommingHolidays = multi.Read<UpcommingHolidaysViewModel>().ToList();
                    objDashboardViewModel.dashboardCountsSummary = multi.Read<DashboardCountsSummaryViewModel>().Single();
                }
                objDBConnection.CloseConnection();
                return objDashboardViewModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }
        public List<WorkAnniversaryViewModel> GetWorkAnniversaries(int userID)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objWorkAnniversaries = objDBConnection.connection.Query<WorkAnniversaryViewModel>("[dbo].[Dashboard_WorkAnniversaries]", new { @UserID = 1 },
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objWorkAnniversaries;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

        public List<BirthDayViewModel> GetBirthdays()
        {
            DBConnection objDBConnection = new DBConnection();

            try
            {

                var objResponse = objDBConnection.connection.Query<BirthDayViewModel>("[dbo].[Dashboard_BirthDays]",
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }
        public List<NewsEventsViewModel> GetNewsAndEvents()
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                DashboardViewModel objDashboardViewModel = new DashboardViewModel();

                var objResponse = objDBConnection.connection.Query<NewsEventsViewModel>("[dbo].[Dashboard_NewsAndEvents]",
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }
        public List<LeavesViewModel> GetTodaysLeaves()
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objResponse = objDBConnection.connection.Query<LeavesViewModel>("[dbo].[Dashboard_TodaysLeaves]",
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }
        public List<LeaveRequestsViewModel> GetLeaveRequests(int userID)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objResponse = objDBConnection.connection.Query<LeaveRequestsViewModel>("[dbo].[Dashboard_LeaveRequests]", new { @UserID = 1 },
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }
        public List<UpcommingHolidaysViewModel> GetUpcommingHolidays()
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                DashboardViewModel objDashboardViewModel = new DashboardViewModel();

                var objResponse = objDBConnection.connection.Query<UpcommingHolidaysViewModel>("[dbo].[Dashboard_UpcommingHolidays]",
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }
        public DashboardCountsSummaryViewModel GetDashboardCountSummary(int UserID)
        {
            DBConnection objDBConnection = new DBConnection();

            try
            {
                var objResponse = objDBConnection.connection.Query<DashboardCountsSummaryViewModel>("[dbo].[Dashboard_CountSummary]", new { @UserID = UserID },
                commandType: CommandType.StoredProcedure).SingleOrDefault();

                objDBConnection.CloseConnection();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }


    }
}
