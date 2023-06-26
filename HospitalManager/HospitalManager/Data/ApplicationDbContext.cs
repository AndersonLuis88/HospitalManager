using HospitalManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HospitalManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Ficha> Ficha { get; set; }
        public DbSet<User> User { get; set; }
    }
}
