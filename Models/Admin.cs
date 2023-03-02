using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalСompetencies1.Models;

public partial class Admin
{
    public short Id { get; set; }
    [Display(Name = "Имя")]
    [Required(ErrorMessage ="*")]
    public string Name { get; set; } = null!;
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "*")]

    public string Password { get; set; } = null!;
}
