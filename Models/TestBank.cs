using System;
using System.Collections.Generic;

namespace DigitalСompetencies1.Models;

public partial class TestBank
{
    public short Id { get; set; }

    public short Category { get; set; }

    public string Question { get; set; } = null!;

    public string Op1 { get; set; } = null!;

    public string Op2 { get; set; } = null!;

    public string? Op3 { get; set; }

    public string? Op4 { get; set; }

    public string CorrectAns { get; set; } = null!;

    public virtual TestCategory CategoryNavigation { get; set; } = null!;
}
