namespace SharedKernel.UserServices.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    string UserIpAddress { get; }
}
