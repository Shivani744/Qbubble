using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Application.Features.Commands.BubbleMeetCommands
{
   public class DeleteBubbleMeetCommand:IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBubbleMeetCommandHandler:IRequestHandler<DeleteBubbleMeetCommand,int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteBubbleMeetCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBubbleMeetCommand command, CancellationToken cancellationToken)
            {
                var meet = await _context.bubbleMeetDetails.Where(m => m.Id == command.Id).FirstOrDefaultAsync();
                if (meet == null)
                    return default;
                _context.bubbleMeetDetails.Remove(meet);
                await _context.SaveChanges();
                return command.Id;
            }
        }
    }

}
