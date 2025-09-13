using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmotiaMart.Domain.Quartz;

[PrimaryKey("SCHED_NAME", "LOCK_NAME")]
[Table("EMOTIA_QRTZ_LOCKS")]
public partial class EMOTIA_QRTZ_LOCK
{
    [Key]
    [StringLength(120)]
    public string SCHED_NAME { get; set; } = null!;

    [Key]
    [StringLength(40)]
    public string LOCK_NAME { get; set; } = null!;
}
