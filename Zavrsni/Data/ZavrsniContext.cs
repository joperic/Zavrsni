using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zavrsni.Models
{
    public class ZavrsniContext : DbContext
    {
        public ZavrsniContext (DbContextOptions<ZavrsniContext> options)
            : base(options)
        {
        }

        public DbSet<Zavrsni.Models.Knjiznicacs> Knjiznicacs { get; set; }
    }
}
