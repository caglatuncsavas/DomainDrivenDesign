namespace DomainDrivenDesign.Domain.Orders;

public sealed record OrderNumber
{
    public string Value { get; init; }
    public OrderNumber(string value)
    {
        if(value.Length == 16)//CTS2024000000000
        {
            throw new ArgumentException("Order number must be 16 characters long");
        }

        Value = value;
    }
};
