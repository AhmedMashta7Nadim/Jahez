using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStractur.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace InfraStractur.Data
{
    public class ConnectDataBase: IdentityDbContext<User>
    {
        public DbSet<User> users { get; set; }
        public DbSet<Departmint> departmints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Jahez-a9412937-2233-493f-b12b-115ca1f49169;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            UserRoleSeed.AddIdentityRole(builder);
            base.OnModelCreating(builder);
        }

    }
}
