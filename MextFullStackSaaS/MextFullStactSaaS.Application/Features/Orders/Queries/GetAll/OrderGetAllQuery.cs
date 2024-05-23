using MediatR;

namespace MextFullStactSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQuery : IRequest<List<OrderGetAllDto>>
    {
    }
}
