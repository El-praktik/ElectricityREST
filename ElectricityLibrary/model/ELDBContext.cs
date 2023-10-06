using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class ELDBContext : DbContext
    {
        public DbSet<Measure> Measure { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ApartUsage> ApartUsage { get; set; }
        public DbSet<Solar> Solar { get; set; }

        public readonly static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ElPraktik;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        
        public ELDBContext(DbContextOptions<ELDBContext> options) : base(options) { }
    }
}
