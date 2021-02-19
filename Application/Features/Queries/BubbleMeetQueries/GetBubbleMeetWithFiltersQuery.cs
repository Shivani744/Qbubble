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
   public class GetBubbleMeetWithFiltersQuery:IRequest<BubbleMeetDetails>
    {
       public string Title { get; set; }
        public class GetBubbleMeetWithFiltersHandler : IRequestHandler<GetBubbleMeetWithFiltersQuery, BubbleMeetDetails>
        {
            private readonly IApplicationDbContext _context;
            public GetBubbleMeetWithFiltersHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<BubbleMeetDetails> Handle(GetBubbleMeetWithFiltersQuery query, CancellationToken cancellationToken)
            {
                var meetList = await _context.bubbleMeetDetails.Where(m=>m.Title==query.Title).FirstOrDefaultAsync();
                if (meetList == null)
                {
                    return null;
                }
               return meetList;
            }
        }
    }
}
