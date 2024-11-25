using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgramCRUD.Models;

namespace ProgramCRUD.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Mahasiswa> tblMahasiswa { get; set; }
        public DbSet<Matkul> Matkul { get; set; }
        public DbSet<Dosen> Dosen { get; set; }

    }
}