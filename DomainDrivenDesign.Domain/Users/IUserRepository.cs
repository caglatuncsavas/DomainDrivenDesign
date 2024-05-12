namespace DomainDrivenDesign.Domain.Users;

public interface IUserRepository
{
    Task<User> CreateAsync(CreateUserDto request, CancellationToken cancellationToken);
    Task<User> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default);
}   
