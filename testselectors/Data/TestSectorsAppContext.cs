using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestSectorsApp.Domin;
using testselectors.Domin;

namespace TestSectorsApp.Data
{
    public class TestSectorsAppContext : DbContext
    {
        public TestSectorsAppContext (DbContextOptions<TestSectorsAppContext> options)
            : base(options)
        {
            
        }

        public DbSet<Sectors> Sectors { get; set; } = default!;
        public DbSet<AcceptForm> AcceptForms { get; set; } = default!;
    }
}
