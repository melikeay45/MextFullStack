using MediatR;
using MextFullStactSaaS.Application.Common.Interfaces;

namespace MextFullStactSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderGetAllDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContect;

        public OrderGetAllQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext)
        {
            _currentUserService = currentUserService;
            _applicationDbContect= applicationDbContext;
        }
        public Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<OrderGetAllDto>());
        }
    }
}
