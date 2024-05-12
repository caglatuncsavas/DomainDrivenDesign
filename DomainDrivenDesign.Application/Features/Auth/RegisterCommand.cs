using CTS.Result;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Auth;
public sealed record RegisterCommand(
    string FullName,
    string Email,
    string Password,
    string Country,
    string City,
    string Town,
    string Street,
    string FullAddress) :IRequest<Result<string>>;
