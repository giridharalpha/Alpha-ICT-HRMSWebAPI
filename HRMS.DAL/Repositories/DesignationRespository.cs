using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessObjects.Models;
using HRMS.DAL.Context;
namespace HRMS.DAL.Repositories
{
  public class DesignationRespository
    {
        public readonly HRMSContext _context;
        public DesignationRespository(HRMSContext context)
        {
            _context = context;
        }
        public DesignationMaster GetDesignation(int id)
        {
            var designation = _context.DesignationMaster.Find(id);
            return designation;
        }
        public List<DesignationMaster> GetDesignations()
        {
            List<DesignationMaster> designations = _context.DesignationMaster.ToList();
            return designations;
        }
    }
}
