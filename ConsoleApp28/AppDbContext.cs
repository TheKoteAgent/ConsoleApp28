using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class AppDbContext :DbContext
    {
        private string _connectionString => "Data Source=DESKTOP-6676I5B;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True;";

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
