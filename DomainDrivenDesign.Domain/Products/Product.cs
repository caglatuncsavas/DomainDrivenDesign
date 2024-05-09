using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Products;

public sealed class Product
{
    public Product(Name name, Description description, Money money, Guid categoryId)
    {
        //ekstra kontroller yapılabilir
        Name = name;
        Description = description;
        Price = money;
    }
    public Guid Id { get; private set; }
    public Name Name { get; private set; } = new(string.Empty);
    public Description Description { get; private set; } = new(string.Empty);
    public Money Price { get; private set; } = Money.Zero();
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public void ChangeName(string name)
    {
        Name = new(name);
    }
}

//public class Test
//{
//    public Test()
//    {
//        Product product = new(new Name("Çağla"), new Description("Description"), Money.Zero());
//        product.ChangeName("Ercan");
//    }
//}
