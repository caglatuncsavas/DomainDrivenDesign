using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories;
public sealed class UserRepository(
    ApplicationDbContext context) : IUserRepository
{
    public async Task<User> CreateAsync(CreateUserDto request, CancellationToken cancellationToken)
    {
        User user = User.CreateUser(
           fullName: request.FullName,
           email: request.Email,
           password: request.Password,
           country: request.Country,
           town: request.Town,
           city: request.City,
           street: request.Street,
           fullAddress: request.FullAddress,
           emailConfirmCode: request.EmailConfirmCode);

        await context.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user;
    }

    public Task<User> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        bool isEmailExists = await context.Users.AnyAsync(u => u.Email == new email, cancellationToken);

       
    }
}
