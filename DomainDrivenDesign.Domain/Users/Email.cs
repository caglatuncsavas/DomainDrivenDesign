namespace DomainDrivenDesign.Domain.Users;

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
