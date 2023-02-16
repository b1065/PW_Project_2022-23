using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chazan.GamesCatalog.DAOSQL
{
    public class DataContext: DbContext
    {
        public DbSet<DO.Producer> Producers { get; set; }
        public DbSet<DO.Game> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=..\\..\\..\\..\\UI\\Database\\DAOSQL.db");
        }
    }
}
