namespace DomainDrivenDesign.Domain.Shared;

public sealed record Name
{
    public Name(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
        if (value.Length < 3)
        {
            throw new ArgumentException("Name must be at least 3 characters long");
        }
        Value = value;
    }
    public string Value { get; init; }
}
