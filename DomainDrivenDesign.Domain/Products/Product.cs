namespace DomainDrivenDesign.Domain.Products;

public sealed class Product
{
    public Product(Name name, Description description, Money money)
    {
        //ekstra kontroller yapılabilir
    }
    public Guid Id { get; private set; }
    public Name Name { get; private set; } = new(string.Empty);
    public Description Description { get; private set; } = new(string.Empty);
    public Money Price { get; private set; } = Money.Zero();
    public void ChangeName(string name)
    {
        Name = new(name);
    }
}

public class Test
{
    public Test()
    {
        Product product = new(new Name("Çağla"), new Description("Description"), Money.Zero());
        product.ChangeName("Ercan");
    }
}

public interface IProductRepository
{
    Task CreateAsync(CreateProductDto request, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}
