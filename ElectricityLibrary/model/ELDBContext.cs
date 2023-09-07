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
        public DbSet<CommunityUsage> CommunityUsages { get; set; }
        public DbSet<ApartUsage> ApartUsages { get; set; }
        public DbSet<BlockUsage> BlockUsages { get; set; }
        public readonly static string ConnectionString = @"data source=DESKTOP-GQ0A8L0;initial catalog=ElPraktik;trusted_connection=true;Encrypt=False;";
        
        public ELDBContext(DbContextOptions<ELDBContext> options) : base(options) { }
    }
}
