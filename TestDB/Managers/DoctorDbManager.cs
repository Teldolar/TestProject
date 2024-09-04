using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDB.Models;
using System.Linq.Dynamic.Core;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace TestDB.Managers
{
    public class DoctorDbManager(TestDBContext dBContext)
    {
        TestDBContext _dbContext = dBContext;
        public List<Doctor> GetDoctors(string orderBy, int page, int pagesize)
        {
            using (_dbContext)
            {
                return _dbContext.Doctors.OrderBy(orderBy)
                                        .Skip((page - 1) * pagesize)
                                        .Take(pagesize)
                                        .ToList();
            }
        }

        public void InsertDoctor(Doctor doctor)
        {
            using (_dbContext)
            {
                _dbContext.Doctors.Add(doctor);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateDoctor(Doctor doctor)
        {
            using (_dbContext)
            {
                _dbContext.Doctors.Update(doctor);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteDoctor(int id)
        {
            using (_dbContext)
            {
                var deletedDoctor = _dbContext.Doctors.First(p => p.Id == id);
                _dbContext.Doctors.Remove(deletedDoctor);
                _dbContext.SaveChanges();
            }
        }

        public Doctor SelectDoctor(int id)
        {
            using (_dbContext)
            {
                return _dbContext.Doctors.FirstOrDefault(p => p.Id.Equals(id));
            }
        }
    }
}
