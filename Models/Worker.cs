using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalСompetencies1.Models;

public partial class Worker
{
    public short Id { get; set; }
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "*")]
    public string Name { get; set; } = null!;
    [Display(Name = "Фамилия")]
    [Required(ErrorMessage = "*")]
    public string LastName { get; set; } = null!;
    [Display(Name = "Должность")]
    [Required(ErrorMessage = "*")]
    public short Position { get; set; }
    [Display(Name = "Почта")]
    [Required(ErrorMessage = "*")]
    public string Email { get; set; } = null!;
    [Display(Name = "Номер")]
    [Required(ErrorMessage = "*")]
    public string Number { get; set; } = null!;
    [Display(Name = "Загрузите фото")]
    public byte[] Image { get; set; } = null!;
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "*")]
    public string Password { get; set; } = null!;

    public virtual Position PositionNavigation { get; set; } = null!;

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
