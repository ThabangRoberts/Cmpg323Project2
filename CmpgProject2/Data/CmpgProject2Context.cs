using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CmpgProject2.Data
{
    public class CmpgProject2Context : DbContext
    {
        public CmpgProject2Context (DbContextOptions<CmpgProject2Context> options)
            : base(options)
        {
        }

        public DbSet<CmpgProject2.Data.OrganizationX> OrganizationX { get; set; }
    }
}
