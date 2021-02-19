using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.PodCommands
{
    public class DeletePodCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePodCommandHandler : IRequestHandler<DeletePodCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeletePodCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePodCommand command, CancellationToken cancellationToken)
            {
                var pod = await _context.podDetails.Where(m => m.Id == command.Id).FirstOrDefaultAsync();
                if (pod == null)
                    return default;
                _context.podDetails.Remove(pod);
                await _context.SaveChanges();
                return command.Id;
            }
        }
    }

}
