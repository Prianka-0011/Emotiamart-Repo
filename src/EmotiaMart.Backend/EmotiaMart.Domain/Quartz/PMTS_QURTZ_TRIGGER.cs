using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmotiaMart.Domain.Quartz;

[PrimaryKey("SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP")]
[Table("EMOTIA_QRTZ_TRIGGERS")]
[Index("SCHED_NAME", "CALENDAR_NAME", Name = "IDX_QRTZ_T_C")]
[Index("SCHED_NAME", "JOB_GROUP", "JOB_NAME", Name = "IDX_QRTZ_T_G_J")]
[Index("SCHED_NAME", "NEXT_FIRE_TIME", Name = "IDX_QRTZ_T_NEXT_FIRE_TIME")]
[Index("SCHED_NAME", "TRIGGER_STATE", "NEXT_FIRE_TIME", Name = "IDX_QRTZ_T_NFT_ST")]
[Index("SCHED_NAME", "MISFIRE_INSTR", "NEXT_FIRE_TIME", "TRIGGER_STATE", Name = "IDX_QRTZ_T_NFT_ST_MISFIRE")]
[Index("SCHED_NAME", "MISFIRE_INSTR", "NEXT_FIRE_TIME", "TRIGGER_GROUP", "TRIGGER_STATE", Name = "IDX_QRTZ_T_NFT_ST_MISFIRE_GRP")]
[Index("SCHED_NAME", "TRIGGER_GROUP", "TRIGGER_STATE", Name = "IDX_QRTZ_T_N_G_STATE")]
[Index("SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP", "TRIGGER_STATE", Name = "IDX_QRTZ_T_N_STATE")]
[Index("SCHED_NAME", "TRIGGER_STATE", Name = "IDX_QRTZ_T_STATE")]
public partial class EMOTIA_QRTZ_TRIGGER
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

    [StringLength(150)]
    public string JOB_NAME { get; set; } = null!;

    [StringLength(150)]
    public string JOB_GROUP { get; set; } = null!;

    [StringLength(250)]
    public string? DESCRIPTION { get; set; }

    public long? NEXT_FIRE_TIME { get; set; }

    public long? PREV_FIRE_TIME { get; set; }

    public int? PRIORITY { get; set; }

    [StringLength(16)]
    public string TRIGGER_STATE { get; set; } = null!;

    [StringLength(8)]
    public string TRIGGER_TYPE { get; set; } = null!;

    public long START_TIME { get; set; }

    public long? END_TIME { get; set; }

    [StringLength(200)]
    public string? CALENDAR_NAME { get; set; }

    public int? MISFIRE_INSTR { get; set; }

    public byte[]? JOB_DATA { get; set; }

    [InverseProperty("EMOTIA_QRTZ_TRIGGER")]
    public virtual EMOTIA_QRTZ_CRON_TRIGGER? EMOTIA_QRTZ_CRON_TRIGGER { get; set; }

    [ForeignKey("SCHED_NAME, JOB_NAME, JOB_GROUP")]
    [InverseProperty("EMOTIA_QRTZ_TRIGGERs")]
    public virtual EMOTIA_QRTZ_JOB_DETAIL EMOTIA_QRTZ_JOB_DETAIL { get; set; } = null!;

    [InverseProperty("EMOTIA_QRTZ_TRIGGER")]
    public virtual EMOTIA_QRTZ_SIMPLE_TRIGGER? EMOTIA_QRTZ_SIMPLE_TRIGGER { get; set; }

    [InverseProperty("EMOTIA_QRTZ_TRIGGER")]
    public virtual EMOTIA_QRTZ_SIMPROP_TRIGGER? EMOTIA_QRTZ_SIMPROP_TRIGGER { get; set; }
}
