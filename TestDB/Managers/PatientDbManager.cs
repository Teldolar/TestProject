using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDB.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Azure;

namespace TestDB.Managers
{
    public class PatientDbManager(TestDBContext dBContext)
    {
        TestDBContext _dbContext = dBContext;
        public List<Patient> GetPatients(string orderBy, int page, int pagesize)
        {
            using (_dbContext)
            {
                return _dbContext.Patients.OrderBy(orderBy)
                                        .Skip((page - 1) * pagesize)
                                        .Take(pagesize)
                                        .ToList();
            }
        }

        public void InsertPatient(Patient patient)
        {
            using (_dbContext)
            {
                _dbContext.Patients.Add(patient);
                _dbContext.SaveChanges();
            }
        }

        public void UpdatePatient(Patient patient)
        {
            using (_dbContext)
            {
                _dbContext.Patients.Update(patient);
                _dbContext.SaveChanges();
            }
        }

        public void DeletePatient(int id)
        {
            using (_dbContext)
            {
                var deletedPatient = _dbContext.Patients.First(p => p.Id == id);
                _dbContext.Patients.Remove(deletedPatient);
                _dbContext.SaveChanges();
            }
        }

        public Patient SelectPatient(int id)
        {
            using (_dbContext)
            {
                return _dbContext.Patients.FirstOrDefault(p => p.Id.Equals(id));
            }
        }
    }
}
