using Directonary.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directonary
{
    internal class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sedma\source\repos\Directonary\Directonary\DB1.mdf;Integrated Security=True");
        


        public DbSet<Location> Locations { get; set; }
    }
}
