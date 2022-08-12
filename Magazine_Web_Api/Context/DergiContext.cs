
using Magazine_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazine_Web_Api.Context
{
    public class DergiContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MagazineDB;Trusted_Connection=True;");

        }
        public DbSet<Dergi> Dergi { get; set; }




    }
}
