namespace ModuleA.DataContext.Entities;

internal record User
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public int Age { get; init; }
    public List<Address>? Addresses { get; init; }
}

internal record Address
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public required string Street { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string ZipCode { get; init; }
}