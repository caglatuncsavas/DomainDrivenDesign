namespace DomainDrivenDesign.Domain.Products;

public sealed record Description
{
    public Description(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Description cannot be null or empty");
        }
        if (value.Length < 3)
        {
            throw new ArgumentException("Description must be at least 3 characters long");
        }
        Value = value;
    }
    public string Value { get; init; }
}