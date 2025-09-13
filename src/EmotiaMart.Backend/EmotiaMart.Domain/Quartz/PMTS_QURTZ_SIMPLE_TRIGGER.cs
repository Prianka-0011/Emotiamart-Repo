using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmotiaMart.Domain.Quartz;

[PrimaryKey("SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP")]
[Table("EMOTIA_QRTZ_SIMPLE_TRIGGERS")]
public partial class EMOTIA_QRTZ_SIMPLE_TRIGGER
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

    public int REPEAT_COUNT { get; set; }

    public long REPEAT_INTERVAL { get; set; }

    public int TIMES_TRIGGERED { get; set; }

    [ForeignKey("SCHED_NAME, TRIGGER_NAME, TRIGGER_GROUP")]
    [InverseProperty("EMOTIA_QRTZ_SIMPLE_TRIGGER")]
    public virtual EMOTIA_QRTZ_TRIGGER EMOTIA_QRTZ_TRIGGER { get; set; } = null!;
}
