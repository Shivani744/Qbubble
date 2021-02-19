using MediatR;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using static Domain.CommonCodes.CommonEnums;
using Application.ApiModels;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Application.Features.Commands.BubbleCommands
{
   public class CreateUpdateBubbleCommand:IRequest<int>
    {
        BubbleDetails apiModel = new BubbleDetails();
        public int Id { get; set; }
        public string BubbleName { get; set; }
        public string BubbleSize { get; set; }
        public string BubbleDescription { get; set; }
        public string BubbleZipCode { get; set; }
        public BubbleType BubbleType { get; set; }
        public DateTime BubbleValidity { get; set; }
        public bool IsOtherCountyMemberAllowed { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public class CreateUpdateBubbleCommandHandler : IRequestHandler<CreateUpdateBubbleCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateUpdateBubbleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateUpdateBubbleCommand command, CancellationToken cancellationToken)
            {
                var bubble = new BubbleDetails();
                bubble.BubbleName = command.BubbleName;
                bubble.BubbleDescription = command.BubbleDescription;
                bubble.BubbleSize = command.BubbleSize;
                bubble.BubbleValidity = command.BubbleValidity;
                bubble.BubbleZipCode = command.BubbleZipCode;
                bubble.BubbleType = command.BubbleType;
                bubble.CreatedBy = command.CreatedBy;
                bubble.UpdatedBy = command.UpdatedBy;
                bubble.IsOtherCountyMemberAllowed = command.IsOtherCountyMemberAllowed;
                if (string.IsNullOrEmpty(Convert.ToString(command.Id))||command.Id==0)
                {
                    _context.bubbleDetails.Add(bubble);
                }
                else
                {
                    BubbleDetails dbModel = _context.bubbleDetails.Where(x => x.Id == command.Id).FirstOrDefault();
                    dbModel.BubbleName= command.BubbleName;
                    dbModel.BubbleDescription= command.BubbleDescription;
                    dbModel.BubbleSize= command.BubbleSize;
                    dbModel.BubbleType= command.BubbleType;
                    dbModel.BubbleValidity= command.BubbleValidity;
                    dbModel.BubbleZipCode= command.BubbleZipCode;
                    dbModel.IsOtherCountyMemberAllowed= command.IsOtherCountyMemberAllowed;
                    dbModel.UpdatedBy= command.UpdatedBy;
                    dbModel.UpdatedOn= DateTime.UtcNow;
                }
               await _context.SaveChanges();
                return command.Id;
            }
        }
    }
}
