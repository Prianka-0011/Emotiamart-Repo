using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmotiaMart.Domain.Quartz;

[PrimaryKey("SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP")]
[Table("EMOTIA_QRTZ_CRON_TRIGGERS")]
public partial class EMOTIA_QRTZ_CRON_TRIGGER
{
    [Key]
    [StringLength(120)]
    public string SCHED_NAME { get; set; } = null!;

    [Key]
    [StringLength(150)]
    public string TRIGGER_NAME { get; set; } = null!;

    [Key]
    [StringLength(150)]
    public string TRIGGER_GROUP { get; set; } = null!;

    [StringLength(120)]
    public string CRON_EXPRESSION { get; set; } = null!;

    [StringLength(80)]
    public string? TIME_ZONE_ID { get; set; }

    [ForeignKey("SCHED_NAME, TRIGGER_NAME, TRIGGER_GROUP")]
    [InverseProperty("EMOTIA_QRTZ_CRON_TRIGGER")]
    public virtual EMOTIA_QRTZ_TRIGGER EMOTIA_QRTZ_TRIGGER { get; set; } = null!;
}
