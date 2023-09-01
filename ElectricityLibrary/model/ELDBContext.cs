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
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CommunityUsage> CommunityUsages { get; set; }
        public DbSet<ApartUsage> ApartUsages { get; set; }
        public DbSet<BlockUsage> BlockUsages { get; set; }
        protected ELDBContext(DbSet<Measure>measures,DbSet<Users>users,DbSet<CommunityUsage>communityUsages,DbSet<ApartUsage>apartUsages,DbSet<BlockUsage>blockUsages)
        {
            Measures = measures;
            Users = users;
            CommunityUsages = communityUsages;
            ApartUsages = apartUsages;
            BlockUsages = blockUsages;
        }
        public ELDBContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-GQ0A8L0;initial catalog=ElPraktik;trusted_connection=true");
        }
        //protected override void OnModelCreating(ModelBuilder DbBuilder)
        //{
            
        //}
    }
}
