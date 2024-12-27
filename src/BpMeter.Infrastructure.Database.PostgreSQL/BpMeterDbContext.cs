using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpMeter.Infrastructure.Database.PostgreSQL;

internal class BpMeterDbContext : DbContext
{
    public DbSet<>

    public BpMeterDbContext(DbContextOptions<BpMeterDbContext> options) : base(options)
    {
    }
}
