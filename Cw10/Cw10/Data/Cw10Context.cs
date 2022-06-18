using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cw10.Models;

namespace Cw10.Data
{
    public class Cw10Context : DbContext
    {
        public Cw10Context (DbContextOptions<Cw10Context> options)
            : base(options)
        {
        }

        public DbSet<Cw10.Models.Movie>? Movie { get; set; }
    }
}
