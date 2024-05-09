﻿namespace DomainDrivenDesign.Domain.Products;

public sealed record Currency
{
    public static readonly Currency USD = new("USD");
    public static readonly Currency TRY = new("TRY");
    private Currency(string code)
    {
        Code = code;
    }
    public string Code { get; init; }

     public static Currency FromCode(string code)
     {
        return All.FirstOrDefault(P => P.Code == code) ?? throw new ArgumentException("Invalid currency code");
     }

    public static readonly IReadOnlyCollection<Currency> All = new[] { USD, TRY };
}
