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
    public class UserController : ControllerBase
    {
        public UserService objUserService;
       
        public UserController(HRMSContext context)
        {
            objUserService = new UserService(context);
        }

        [HttpGet("GetUsers")]
        public ResultViewModel<List<User>> GetUsers()
        {
            ResultViewModel<List<User>> objResult = objUserService.GetUsers();
            return objResult;
        }

        [HttpGet("GetUser/{id}")]
        public ResultViewModel<User> GetUser(int id)
        {
            ResultViewModel<User> objResult = objUserService.GetUser(id);
            return objResult;
        }

        [HttpPost]
        public ResultViewModel<User> AddUser(User objUser)
        {
            ResultViewModel<User> objResult = objUserService.AddUser(objUser);
            return objResult;
        }

        [HttpPut("{id}")]
        public ResultViewModel<string> UpdateUser(int id, User objUser)
        {
            ResultViewModel<string> objResult = objUserService.UpdateUser(id, objUser);
            return objResult;
        }
        [HttpDelete("{id}")]
        public ResultViewModel<string> DeleteUser(int id)
        {
            ResultViewModel<string> objResult = objUserService.DeleteUser(id);
            return objResult;
        }
        [HttpPut("Login")]
        public ResultViewModel<User> Login(string username,string password)
        {
            ResultViewModel<User> objResult = objUserService.Login(username,password);
            return objResult;
        }
        [HttpPut("ChangePassword")]
        public ResultViewModel<string> ChangePassword(ChangePasswordViewModel objChangePasswordViewModel)
        {
            ResultViewModel<string> objResult = objUserService.ChangePassword(objChangePasswordViewModel);
            return objResult;
        }
    }
}
