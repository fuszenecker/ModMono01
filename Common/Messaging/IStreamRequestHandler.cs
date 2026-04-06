namespace Common.Messaging;

public interface IStreamRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    IAsyncEnumerable<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}