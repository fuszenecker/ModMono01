using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace ModuleA.Contracts;

public record User
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public int Age { get; init; }
}

public record UserRequest : IRequest<User>
{
    public required int UserId { get; init; }
}