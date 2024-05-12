using FluentEmail.Core;
using MediatR;

namespace DomainDrivenDesign.Domain.Users.Events;

public sealed class SendConfirmEmailForUserDomainEvenet(
    IUserRepository userRepository,
    IFluentEmail fluentEmail) : INotificationHandler<UserDomainEvent>
{
    public async Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
    {
       User? user = await userRepository.GetByIdAsync(notification.UserId, cancellationToken);
        if (user is null)
        {
              throw new Exception("User not found");
        }

        //mail gönderme işlemi

        await fluentEmail
            .To(user.Email.Value)
            .Subject("Mail Confirm")
            .Body($"You can use this code for confirm your email. Code: {user.EmailConfirmCode}")
            .SendAsync(cancellationToken);
    }
}
