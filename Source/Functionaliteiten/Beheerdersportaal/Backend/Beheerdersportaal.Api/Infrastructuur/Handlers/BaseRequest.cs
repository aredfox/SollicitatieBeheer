using MediatR;

namespace Beheerdersportaal.Api.Infrastructuur.Handlers
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse>
        where TResponse : BaseResponse
    {
    }
}
