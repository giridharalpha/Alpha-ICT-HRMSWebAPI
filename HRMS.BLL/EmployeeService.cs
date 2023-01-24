using System;
using HRMS.BusinessObjects.Models;
using System.Linq;
using System.Threading.Tasks;
using HRMS.DAL.Repositories;
using HRMS.DAL.Context;
using System.Collections.Generic;

namespace HRMS.BLL
{
    public class EmployeeService
    {
        private EmployeeRepository objEmployeeRepository;
        public EmployeeService(HRMSContext context)
        {
            objEmployeeRepository = new EmployeeRepository(context);
        }

        public ResultViewModel<List<Employee>> GetEmployees()
        {
            try
            {
                List<Employee> objResponse = objEmployeeRepository.GetEmployees();
                if (objResponse == null)
                {
                    return new ResultViewModel<List<Employee>> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<List<Employee>> { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<Employee>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }

        }
        public ResultViewModel<Employee> GetEmployee(int id)
        {
            try
            {
                Employee objResponse = objEmployeeRepository.GetEmployee(id);
                if (objResponse == null)
                {
                    return new ResultViewModel<Employee> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<Employee> { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<Employee> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };

            }
        }
        public ResultViewModel<Employee> AddEmployee(Employee objEmployee)
        {
            try
            {
                if (objEmployee == null)
                {
                    return new ResultViewModel<Employee> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.InvalidData };
                }               
                else
                {
                    Employee objResult = objEmployeeRepository.AddEmployee(objEmployee);
                    return new ResultViewModel<Employee> { Result = objResult, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };

                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<Employee> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };

            }
        }
        public ResultViewModel<string> UpdateEmployee(int id, Employee objEmployee)
        {
            try
            {
                if (objEmployee == null)
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.InvalidData };
                }
                else if (id <= 0)
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "Please provide a valid Id" };

                }
                else
                {
                    bool result = objEmployeeRepository.UpdateEmployee(id, objEmployee);
                    if (result)
                    {
                        return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.RecordUpdatedMessage };

                    }
                    else
                    {
                        return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "Record not updated" };

                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };

            }
        }
        public ResultViewModel<string> DeleteEmployee(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "Please provide a valid Id" };

                }
                else
                {
                    Employee objResult = objEmployeeRepository.GetEmployee(id);

                    if (objResult == null)
                    {
                        return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                    }
                    else
                    {
                        objEmployeeRepository.DeleteEmployee(id);
                        return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.RecordDeletedMessage };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };

            }
        }
       
    }
}
