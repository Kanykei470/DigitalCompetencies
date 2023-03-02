using System;
using System.Collections.Generic;

namespace DigitalСompetencies1.Models;

public partial class Position
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
