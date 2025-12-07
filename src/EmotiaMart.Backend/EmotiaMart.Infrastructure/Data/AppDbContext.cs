
using Microsoft.EntityFrameworkCore;
using EmotiaMart.Domain.Entities;
using EmotiaMart.Domain.Quartz;

namespace EmotiaMart.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public Guid currentUserId { get; set; } = Guid.Empty;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.AddInterceptors(new AuditInterceptor(currentUserId));
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<AuditEntry> AuditEntries { get; set; } = null!;
        public virtual DbSet<EMOTIA_QRTZ_BLOB_TRIGGER> EMOTIA_QRTZ_BLOB_TRIGGERs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_CALENDAR> EMOTIA_QRTZ_CALENDARs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_CRON_TRIGGER> EMOTIA_QRTZ_CRON_TRIGGERs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_FIRED_TRIGGER> EMOTIA_QRTZ_FIRED_TRIGGERs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_JOB_DETAIL> EMOTIA_QRTZ_JOB_DETAILs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_LOCK> EMOTIA_QRTZ_LOCKs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_PAUSED_TRIGGER_GRP> EMOTIA_QRTZ_PAUSED_TRIGGER_GRPs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_SCHEDULER_STATE> EMOTIA_QRTZ_SCHEDULER_STATEs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_SIMPLE_TRIGGER> EMOTIA_QRTZ_SIMPLE_TRIGGERs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_SIMPROP_TRIGGER> EMOTIA_QRTZ_SIMPROP_TRIGGERs { get; set; }

        public virtual DbSet<EMOTIA_QRTZ_TRIGGER> EMOTIA_QRTZ_TRIGGERs { get; set; }

    }
}
