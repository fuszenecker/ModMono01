using MediatR;
using ModuleA.Entities;

namespace ModuleA.Contracts;

public record UserRequest : IRequest<User>
{
    public required int UserId { get; init; }
}

public record UserCountRequest : IRequest<int>;