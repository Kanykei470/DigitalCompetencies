using System;
using System.Collections.Generic;

namespace DigitalСompetencies1.Models;

public partial class TextsBank
{
    public short Id { get; set; }

    public string Text { get; set; } = null!;

    public short Symbols { get; set; }

    public TimeSpan ExpectedTime { get; set; }
}
