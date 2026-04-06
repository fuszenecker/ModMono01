namespace Common.Messaging;

public interface ICommandHandler<TRequest> where TRequest : ICommand
{
    Task Handle(TRequest request, CancellationToken cancellationToken);
}