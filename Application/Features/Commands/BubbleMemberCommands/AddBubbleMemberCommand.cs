using MediatR;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Application.ApiModels;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Application.Features.Commands.BubbleMemberCommands
{
    public class AddBubbleMemberCommand:IRequest<int>
    {
        public int BubbbleId { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        public List<int> UserIds { get; set; }


        public class AddBubbleMemberCommandHandler : IRequestHandler<AddBubbleMemberCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddBubbleMemberCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(AddBubbleMemberCommand command, CancellationToken cancellationToken)
            {
                
                foreach (var item in command.UserIds)
                {
                    var member = new BubbleMembers();
                    member.BubbleId = command.BubbbleId;
                    member.UserId = item;
                    member.CreatedBy = command.createdBy;
                    member.UpdatedBy = command.updatedBy;
                    _context.bubbleMembers.Add(member);
                   await _context.SaveChanges();
                }
                return command.BubbbleId;
            }
        }
    }
}
