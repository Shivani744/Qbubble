using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;
using System.Collections.Generic;
namespace Application.Features.Queries.BubbleMemberQueries
{
   public class GetBubbleMembersByBubbleIdQuery:IRequest<IEnumerable<BubbleMembers>>
    {
        public int BubbleId { get; set; } 
        public class GetBubbleMembersByBubbleIdHandler : IRequestHandler<GetBubbleMembersByBubbleIdQuery, IEnumerable<BubbleMembers>>
        {
            private readonly IApplicationDbContext _context;
            public GetBubbleMembersByBubbleIdHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<BubbleMembers>> Handle(GetBubbleMembersByBubbleIdQuery query, CancellationToken cancellationToken)
            {
                var members = await _context.bubbleMembers.Where(m=>m.BubbleId==query.BubbleId).ToListAsync();
                if (members == null)
                {
                    return null;
                }
                return members.AsReadOnly();
            }
        }

    }
}
