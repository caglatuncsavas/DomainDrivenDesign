using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;


namespace DomainDrivenDesign.Domain.Products;

public sealed class Product : Entity
{
    public Product(Name name, Description description, Money money, Guid categoryId)
    {
        //ekstra kontroller yapılabilir
        Name = name;
        Description = description;
        Price = money;
        CategoryId = categoryId;
    }
    public Name Name { get; private set; }
    public Description Description { get; private set; } 
    public Money Price { get; private set; } 
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
