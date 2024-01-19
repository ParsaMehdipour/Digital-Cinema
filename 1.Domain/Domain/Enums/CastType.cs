using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum CastType
{
    [Display(Name = "Actor/Actress")]
    ActorActress = 0,

    [Display(Name = "Director")]
    Director = 1,

    [Display(Name = "Writer")]
    Writer = 2
}
