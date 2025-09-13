using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmotiaMart.Domain.Quartz;

[PrimaryKey("SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP")]
[Table("EMOTIA_QRTZ_BLOB_TRIGGERS")]
public partial class EMOTIA_QRTZ_BLOB_TRIGGER
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

    public byte[]? BLOB_DATA { get; set; }
}
