using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Application.Features.Commands.BubbleCommands
{
    public class GetBubbleByBubbleIdQuery : IRequest<BubbleDetails>
    {
        public int Id { get; set; }
        public class GetBubbleByBubbleIdQueryHandler : IRequestHandler<GetBubbleByBubbleIdQuery, BubbleDetails>
        {
            private readonly IApplicationDbContext _context;
            public GetBubbleByBubbleIdQueryHandler(IApplicationDbContext context) => _context = context;

            public async Task<BubbleDetails> Handle(GetBubbleByBubbleIdQuery query, CancellationToken cancellationToken)
            {
                var bubble = _context.bubbleDetails.Where(a => a.Id == query.Id).FirstOrDefault();
                if (bubble == null)
                {
                    return null;
                }
                return bubble;
            }
        }
    }
}