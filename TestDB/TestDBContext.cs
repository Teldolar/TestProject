using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestDB.Models;

namespace TestDB
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Cabinet> Cabinets { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Specialisation> Specialisations { get; set; }
    }
}
