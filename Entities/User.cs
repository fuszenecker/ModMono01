namespace Entities;

public record User
{
    public required string Name { get; init; }
    public int Age { get; init; }
    public List<Address>? Addresses { get; init; }
}
