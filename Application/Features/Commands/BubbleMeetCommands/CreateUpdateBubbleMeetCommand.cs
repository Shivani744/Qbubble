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

namespace Application.Features.Commands.BubbleMeetCommands
{

    public class CreateUpdateBubbleMeetCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public List<BubbleApiModel> ChooseBubble { get; set; }
        public string MeetDescription { get; set; }
        public DateTime MeetTiming { get; set; }
        public string MeetPlace { get; set; }
        public string ZipCode { get; set; }
        public bool AllowChat { get; set; }
        public UserPermission UserPermission { get; set; }
        public int BubbleId { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }


        public class CreateUpdateBubbleMeetCommandHandler : IRequestHandler<CreateUpdateBubbleMeetCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateUpdateBubbleMeetCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateUpdateBubbleMeetCommand command, CancellationToken cancellationToken)
            {
                var meet = new BubbleMeetDetails();
                meet.Title = command.Title;
                meet.MeetDescription= command.MeetDescription;
                meet.MeetPlace= command.MeetPlace;
                meet.MeetTiming= command.MeetTiming;
                meet.UpdatedBy= command.UpdatedBy;
                meet.CreatedBy= command.CreatedBy;
                meet.BubbleId= command.BubbleId;
                meet.ZipCode= command.ZipCode;
                meet.UserPermission= command.UserPermission;
                meet.AllowChat= command.AllowChat;
                if (string.IsNullOrEmpty(Convert.ToString(command.Id)) || command.Id == 0)
                {
                    _context.bubbleMeetDetails.Add(meet);
                }
                else {
                    BubbleMeetDetails dbModel = _context.bubbleMeetDetails.Where(m => m.Id == command.Id).FirstOrDefault();
                    dbModel.Title = command.Title;
                    dbModel.MeetDescription = command.MeetDescription;
                    dbModel.MeetPlace = command.MeetPlace;
                    dbModel.MeetTiming = command.MeetTiming;
                    dbModel.UpdatedOn = DateTime.UtcNow;
                    dbModel.UpdatedBy = command.UpdatedBy;
                    dbModel.BubbleId = command.BubbleId;
                    dbModel.ZipCode = command.ZipCode;
                    dbModel.UserPermission = command.UserPermission;
                    dbModel.AllowChat = command.AllowChat;
                }
                await _context.SaveChanges();
                return command.Id;

            }
        }
    }
}
