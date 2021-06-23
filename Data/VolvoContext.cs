using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volvo.Models;

namespace Volvo.Data
{
    public class VolvoContext : DbContext
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Volvo;Integrated Security=True;";

        public VolvoContext (DbContextOptions<VolvoContext> options) : base(options) { }

        public DbSet<Caminhao> Caminhoes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
