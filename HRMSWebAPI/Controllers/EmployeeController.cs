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
    public class EmployeeController : ControllerBase
    {
        public EmployeeService objEmployeeService;
       
        public EmployeeController(HRMSContext context)
        {
            objEmployeeService = new EmployeeService(context);          

        }
        [HttpGet("GetEmployees")]
        public ResultViewModel<List<Employee>> GetEmployees()
        {
            ResultViewModel<List<Employee>> objResult = objEmployeeService.GetEmployees();
            return objResult;
        }

        [HttpGet("GetEmployee/{id}")]
        public ResultViewModel<Employee> GetEmployee(int id)
        {
            ResultViewModel<Employee> objResult = objEmployeeService.GetEmployee(id);
            return objResult;
        }

        [HttpPost]
        public ResultViewModel<Employee> AddEmployee(Employee objEmployee)
        {
            ResultViewModel<Employee> objResult = objEmployeeService.AddEmployee(objEmployee);
            return objResult;
        }

        [HttpPut("{id}")]
        public ResultViewModel<string> UpdateEmployee(int id, Employee objEmployee)
        {
            ResultViewModel<string> objResult = objEmployeeService.UpdateEmployee(id, objEmployee);
            return objResult;
        }
        [HttpDelete("{id}")]
        public ResultViewModel<string> DeleteEmployee(int id)
        {
            ResultViewModel<string> objResult = objEmployeeService.DeleteEmployee(id);
            return objResult;
        }
    }
}
