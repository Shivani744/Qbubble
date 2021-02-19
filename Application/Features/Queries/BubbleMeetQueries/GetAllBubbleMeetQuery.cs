using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.BubbleMeetQueries
{
   public class GetAllBubbleMeetQuery:IRequest<IEnumerable<BubbleMeetDetails>>
    {
        public class GetAllBubbleMeetQueriesHandler : IRequestHandler<GetAllBubbleMeetQuery, IEnumerable<BubbleMeetDetails>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBubbleMeetQueriesHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<BubbleMeetDetails>> Handle(GetAllBubbleMeetQuery query, CancellationToken cancellationToken)
            {
                var meetList = await _context.bubbleMeetDetails.ToListAsync();
                if (meetList == null)
                {
                    return default;
                }
                return meetList.AsReadOnly();
            }
        }
    }
}
