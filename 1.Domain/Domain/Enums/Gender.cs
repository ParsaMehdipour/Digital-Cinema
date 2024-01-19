using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum Gender
{
    [Display(Name = "Male")]
    Male = 0,

    [Display(Name = "Female")]
    Female = 1
}
