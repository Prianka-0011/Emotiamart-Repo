using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmotiaMart.Domain.Quartz;

[PrimaryKey("SCHED_NAME", "CALENDAR_NAME")]
[Table("EMOTIA_QRTZ_CALENDARS")]
public partial class EMOTIA_QRTZ_CALENDAR
{
    [Key]
    [StringLength(120)]
    public string SCHED_NAME { get; set; } = null!;

    [Key]
    [StringLength(200)]
    public string CALENDAR_NAME { get; set; } = null!;

    public byte[] CALENDAR { get; set; } = null!;
}
