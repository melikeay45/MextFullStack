using MediatR;
using MextFullStackSaaS.Application.Common.Models;

namespace MextFullStactSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommand : IRequest<ResponseDto<Guid>>
    {
        public Guid Id { get; set; }

        public OrderDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
