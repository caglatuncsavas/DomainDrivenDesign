using AutoMapper;
using CTS.Result;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Users.Events;
using MediatR;
using System.Globalization;

namespace DomainDrivenDesign.Application.Features.Auth;
internal sealed class RegisterCommandHandler(
    IUserRepository userRepository,
    IMapper mapper,
    IMediator mediator) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExists = await userRepository.IsEmailExistsAsync(request.Email, cancellationToken);

        if (isEmailExists)
        {
            return Result<string>.Failure("Email is already exists");
        }


        string emailConfirmCode = new Random().Next(1000, 9999).ToString();

        CreateUserDto createUserDto = mapper.Map<CreateUserDto>(request);

        createUserDto.EmailConfirmCode = emailConfirmCode;

        User user = await userRepository.CreateAsync(createUserDto, cancellationToken);

        await mediator.Publish(new UserDomainEvent(user.Id));

        return Result<string>.Succeed("Register is successful");
    }
}
