using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;
public enum TicketType
{
    [Display(Name = "Online")]
    Online = 0,

    [Display(Name = "Onsite")]
    Onsite = 1
}
