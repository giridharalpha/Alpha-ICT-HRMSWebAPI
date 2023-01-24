using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessObjects.Models;
using HRMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using Dapper;
namespace HRMS.DAL.Repositories
{
    public class EmployeeRepository
    {
        public readonly HRMSContext _context;
        public EmployeeRepository(HRMSContext context)
        {            
            _context = context;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _context.Employee.ToList();
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            var employee = _context.Employee.Find(id);
            return employee;
        }
        public Employee  AddEmployee(Employee objEmployee)
        {

            Employee _objEmployee = new Employee();
            try
            {
                _context.Employee.Add(objEmployee);
                _context.SaveChanges();
                _objEmployee = _context.Employee.Find(objEmployee.EmployeeID);
                return _objEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateEmployee(int id, Employee objEmployee)
        {
            try
            {
                _context.Entry(objEmployee).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                var objEmployee = GetEmployee(id);
                _context.Employee.Remove(objEmployee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
