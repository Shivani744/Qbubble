using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.BubbleQueries
{
   public class GetAllBubbleQuery:IRequest<IEnumerable<BubbleDetails>>
    {
        public class GetAllBubbleQueryHandler : IRequestHandler<GetAllBubbleQuery, IEnumerable<BubbleDetails>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBubbleQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<BubbleDetails>> Handle(GetAllBubbleQuery query, CancellationToken cancellationToken)
            {
                var bubbleList = await _context.bubbleDetails.ToListAsync();
                if (bubbleList == null)
                {
                    return null;
                }
                return bubbleList.AsReadOnly();
            }
        }
    }
}
