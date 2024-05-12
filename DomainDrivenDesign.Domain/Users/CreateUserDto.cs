namespace DomainDrivenDesign.Domain.Users;

public sealed record CreateUserDto
{
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string Town { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string Street { get; init; } = string.Empty;
    public string FullAddress { get; init; } = string.Empty;
    public string EmailConfirmCode { get; init; } = string.Empty;
}
