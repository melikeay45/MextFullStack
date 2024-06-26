﻿using MediatR;
using MextFullStactSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullStactSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderGetAllDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderGetAllQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext)
        {
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            return _applicationDbContext
                 .Orders
                 .Where(x => x.UserId == _currentUserService.UserId)
                 .Select(o => OrderGetAllDto.FromOrder(o))
                 .ToListAsync(cancellationToken);

            // CommonTranslations.en-GB.resx WelcomeMessage => "Hello Alper";
            // CommonTranslations.tr-TR.resx WelcomeMessage => "Merhaba Alper";
        }
    }
}
