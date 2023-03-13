using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalСompetencies1.Models;

public partial class TestBank
{
    [Key]
    public short Id { get; set; }
    [Display(Name = "Категория")]
    [Required(ErrorMessage = "*")]
    public short Category { get; set; }
    [Display(Name = "Текст вопроса")]
    [Required(ErrorMessage = "*")]
    public string Question { get; set; } = null!;
    [Display(Name = "Вариант-1")]
    [Required(ErrorMessage = "*")]
    public string Op1 { get; set; } = null!;
    [Display(Name = "Вариант-2")]
    [Required(ErrorMessage = "*")]
    public string Op2 { get; set; } = null!;
    [Display(Name = "Вариант-3")]
    [Required(ErrorMessage = "*")]
    public string? Op3 { get; set; }
    [Display(Name = "Вариант-4")]
    [Required(ErrorMessage = "*")]
    public string? Op4 { get; set; }
    [Display(Name = "Правильный ответ")]
    [Required(ErrorMessage = "*")]
    public string CorrectAns { get; set; } = null!;
    [Display(Name = "Выбрать категорию")]
    [Required(ErrorMessage = "*")]
    public Nullable<short> q_fk_catid { get; set; }

    public virtual TestCategory CategoryNavigation { get; set; } = null!;
}
