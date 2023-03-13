using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalСompetencies1.Models;

public partial class TestCategory
{
    public TestCategory()
    {
        this.TestBanks = new HashSet<TestBank>();
    }

    [Key]
    public short Id { get; set; }
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "*")]
    public string? Name { get; set; }
    [Display(Name = "Описание")]
    [Required(ErrorMessage = "*")]
    public string? Descriprion { get; set; }
    public Nullable<short> cat_fk_adid { get; set; }

    public virtual Admin Admin { get; set; }
    public virtual ICollection<TestBank> TestBanks { get; } = new List<TestBank>();
}
