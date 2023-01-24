using System;
using HRMS.BusinessObjects.Models;
using System.Linq;
using System.Threading.Tasks;
using HRMS.DAL.Repositories;
using HRMS.DAL.Context;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace HRMS.BLL
{
    public class UserService
    {
        private UserRepository objUserRepository;
        public UserService(HRMSContext context)
        {
            objUserRepository = new UserRepository(context);
        }
        public ResultViewModel<List<User>> GetUsers()
        {
            try
            {
                List<User> objResponse = objUserRepository.GetUsers();
                if (objResponse == null)
                {
                    return new ResultViewModel<List<User>> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<List<User>> { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<User>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };
            }

        }
        public ResultViewModel<User> GetUser(int id)
        {
            try
            {
                User objResponse = objUserRepository.GetUser(id);
                if (objResponse == null)
                {
                    return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                }
                else
                {
                    return new ResultViewModel<User> { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.Message };

            }
        }

        public ResultViewModel<User> AddUser(User objUser)
        {
            try
            {
                if (objUser == null)
                {
                    return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.InvalidData };
                }

                else if (objUserRepository.IsUserExists(objUser.UserName))
                {
                    return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "User already exists with same name" };

                }
                else
                {
                    User objResult = objUserRepository.AddUser(objUser);
                    return new ResultViewModel<User> { Result = objResult, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };

                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };

            }
        }
        public ResultViewModel<string> UpdateUser(int id, User objUser)
        {
            try
            {
                if (objUser == null)
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.InvalidData };
                }
                else if (id <= 0)
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "Please provide a valid Id" };

                }

                else if (objUserRepository.IsUserExists(objUser.UserName))
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "User already exists" };

                }
                else
                {
                    bool result = objUserRepository.UpdateUser(id, objUser);
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
        public ResultViewModel<string> DeleteUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "Please provide a valid Id" };

                }
                else
                {
                    User objResult = objUserRepository.GetUser(id);

                    if (objResult == null)
                    {
                        return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.RecordNotFoundMessage };
                    }
                    else
                    {
                        objUserRepository.DeleteUser(id);
                        return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.RecordDeletedMessage };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };

            }
        }

        public ResultViewModel<User> Login(string username, string password)
        {
            try
            {
                User objUser = new User();
                if (string.IsNullOrEmpty(username))
                {
                    return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "User name is not valid" };

                }
                else if (string.IsNullOrEmpty(password))
                {
                    return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Password is not valid" };
                }
                else
                {
                    objUser = objUserRepository.Login(username, password);
                    if (objUser != null)
                    {
                        return new ResultViewModel<User> { Result = objUser, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "Login successfull" };
                    }
                    else
                    {
                        return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = "User does not exists..!!" };


                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<User> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };

            }

        }
        public ResultViewModel<string> ChangePassword(ChangePasswordViewModel objChangePasswordViewModel)
        {
            try
            {
                PasswordSecurity objPasswordSecurity = new PasswordSecurity();
                string regexstring = @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$";
                string errorMSG = "";
                User objUser = new User();

                if (string.IsNullOrEmpty(objChangePasswordViewModel.ConfirmPassword))
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Confirm Password required" };
                }
                else if (string.IsNullOrEmpty(objChangePasswordViewModel.Password))
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Password is required" };
                }
                else if (!objUserRepository.UserOldPasswordExists(objPasswordSecurity.Encrypt(objChangePasswordViewModel.OldPassword)))
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Old Password does not match" };
                }
                else if (objChangePasswordViewModel.Password != objChangePasswordViewModel.ConfirmPassword)
                {
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Password and confirm password doesn't match" };
                }
                else if (!Regex.Match(objChangePasswordViewModel.Password, regexstring).Success)
                {
                    errorMSG = "Required atleast one lowercase, one uppercase letter, one special character, one digit and minimum length should 8 characters ";
                    return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = errorMSG };
                }
                else
                {
                    objUser = objUserRepository.GetUser(objChangePasswordViewModel.UserId);
                    if (objUser != null)
                    {
                        objUser.Password = objPasswordSecurity.Encrypt(objChangePasswordViewModel.Password);
                        bool res = objUserRepository.UpdateUser(objUser.UserID, objUser);
                        if (res)
                        {
                            return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Success.ToString(), UserMessage = "Password changed successfully" };
                        }
                        else
                        {
                            return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "Password Not Changed" };

                        }
                    }
                    else
                    {
                        return new ResultViewModel<string> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "User does not exists..!!" };

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
