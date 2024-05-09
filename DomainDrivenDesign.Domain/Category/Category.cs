using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;

namespace DomainDrivenDesign.Domain.Category;
public sealed class Category : Entity
{
    public Name Name { get; set; }
    public ICollection<Product>? Products { get; private set; }
    public Category(string name)
    {
        Name = new(name);
    }
}
