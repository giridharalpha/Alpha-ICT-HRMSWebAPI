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
    public class UserRepository
    {
        public readonly HRMSContext _context;
        public UserRepository(HRMSContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            try
            {
                List<User> objUsers = _context.UserMaster.ToList();
                return objUsers;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public User GetUser(int id)
        {
            try
            {
                User objUser = _context.UserMaster.Find(id);
                return objUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public User AddUser(User objUser)
        {

            User _objUser = new User();
            try
            {
                _context.UserMaster.Add(objUser);
                _context.SaveChanges();
                _objUser = _context.UserMaster.Find(objUser.UserID);
                return _objUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateUser(int id, User objUser)
        {
            try
            {
                _context.Entry(objUser).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                var objUser = GetUser(id);
                _context.UserMaster.Remove(objUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsUserExists(string UserName)
        {
            try
            {
                return _context.UserMaster.Any(e => e.UserName == UserName);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public User Login(string username, string password)
        {
            try
            {
                User objUser = _context.UserMaster.Where(o => o.UserName == username && o.Password == password).SingleOrDefault();
                return objUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool UserOldPasswordExists(string oldPassword)
        {
            try{
                return _context.UserMaster.Any(e => e.Password == oldPassword);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
