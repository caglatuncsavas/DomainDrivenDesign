namespace DomainDrivenDesign.Domain.Products;

public sealed record Money(decimal Amount, Currency Currency)
{
    public static Money operator + (Money a, Money b)
    {
        if(a.Currency != b.Currency)
        {
            throw new ArgumentException("Cannot add money with different currencies");
        }

        return new(a.Amount + b.Amount, a.Currency);
    }
    public static Money Zero() => new(0, Currency.TRY);
    public static Money Zero(Currency currency) => new(0, currency);//overload for currency parameter to create zero money with different currency

    public bool IsZero() => this == Zero(Currency);
}
