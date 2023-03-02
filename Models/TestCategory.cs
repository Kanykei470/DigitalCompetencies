using System;
using System.Collections.Generic;

namespace DigitalСompetencies1.Models;

public partial class TestCategory
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public string? Descriprion { get; set; }

    public virtual ICollection<TestBank> TestBanks { get; } = new List<TestBank>();
}
