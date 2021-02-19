using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Application.Features.Commands.BubbleCommands
{
   public class DeleteBubbleCommand:IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBubbleCommandHandler : IRequestHandler<DeleteBubbleCommand, int>
        {
            private readonly IApplicationDbContext _context;
           public DeleteBubbleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBubbleCommand command, CancellationToken cancellationToken)
            {
                var bubble = await _context.bubbleDetails.Where(b => b.Id == command.Id).FirstOrDefaultAsync();
                if (bubble == null)
                    return default;
                _context.bubbleDetails.Remove(bubble);
                await _context.SaveChanges();
                return bubble.Id;
            }
        }
    }
}
