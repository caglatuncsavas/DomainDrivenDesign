using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;

namespace DomainDrivenDesign.Domain.Users;
public sealed class User : Entity
{
    private User(Name fullName, Email email, Password password, Address address)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        Address = address;
    }
    public Name FullName { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Address Address { get; private set; }
    public static User CreateUser(string fullName, string email, string password, string country, string town,string city, string street, string fullAddress)
    {
        //İş Kuralları
        User user = new(
            fullName : new(fullName),
            email :new(email),
            password: new(password),
            address: new(country, town, city, street, fullAddress));

        return user;
    }
    public void ChangeName(string fullName)
    {
        FullName = new(fullName);
    }
}

public sealed record Email
{
    public string Value { get; init; }
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Email cannot be empty");
        }

        if (!value.Contains("@"))
        {
            throw new ArgumentException("Email is not valid");
        }

        Value = value;
    }
}

public sealed record Password
{
    public string Value { get; init; }
    public Password(string value)
    {
        if(value.Length < 6)
        {
            throw new ArgumentException("Password must be at least 6 characters");
        }

        Value = value;
    }
}

public sealed record Address(
    string Country,
    string City,
    string Town,
    string Street,
    string FullAddress);

public interface IUserRepository
{
    Task<User> CreateAsync(CreateUserDto request, CancellationToken cancellationToken);
    Task<User> GetAllAsync(CancellationToken cancellationToken = default);
}   

public sealed record CreateUserDto(
       string FullName,
       string Email,
       string Password,
       string Country,
       string City,
       string Town,
       string Street,
       string FullAddress);
