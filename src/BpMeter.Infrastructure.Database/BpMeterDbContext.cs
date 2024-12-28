using BpMeter.Infrastructure.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace BpMeter.Infrastructure.Database.PostgreSQL;

public class BpMeterDbContext(DbContextOptions<BpMeterDbContext> options) : DbContext(options)
{
    public DbSet<PersonalInformationEntity> PersonalInformation { get; set; }

    public DbSet<BloodPressureEntity> BloodPressures { get; set; }

    public DbSet<BodyWeightEntity> BodyWeights { get; set; }
}
