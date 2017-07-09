using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beheerdersportaal.Api.Infrastructuur.Handlers
{
    public abstract class DbRequestHandler<TDatabase, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TDatabase : DbContext
        where TRequest : IRequest<TResponse>
    {
        protected readonly TDatabase _db;
        public DbRequestHandler(TDatabase database) => _db = database;
        public abstract TResponse Handle(TRequest message);        
    }
}
