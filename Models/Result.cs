using System;
using System.Collections.Generic;

namespace DigitalСompetencies1.Models;

public partial class Result
{
    public short Id { get; set; }

    public short? IdWorker { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public double? Result1 { get; set; }

    public virtual Worker? IdWorkerNavigation { get; set; }
}
