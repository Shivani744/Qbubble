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

namespace Application.Features.Commands.PodCommands
{

    public class CreateUpdatePodCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string PODName { get; set; }
       public string BubbleAdded { get; set; }
        public string DistributionCount { get; set; } 
        public bool IsAllowtoEdit { get; set; }
        public bool IsDelete{ get; set; }
        public bool IsCreateMeet { get; set; }
        public int BubbleId { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }


        public class CreateUpdatePodCommandHandler : IRequestHandler<CreateUpdatePodCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateUpdatePodCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateUpdatePodCommand command, CancellationToken cancellationToken)
            {
                var pod = new PodDetails();
                pod.PODName = command.PODName;
                pod.BubbleAdded = command.BubbleAdded;
                pod.DistributionCount = command.DistributionCount;
                pod.IsAllowtoEdit = command.IsAllowtoEdit;
                pod.IsCreateMeet = command.IsCreateMeet;
                pod.CreatedBy = command.CreatedBy;
                pod.UpdatedBy = command.UpdatedBy;
                pod.BubbleId = command.BubbleId;
                pod.IsDelete = command.IsDelete;
   
                if (string.IsNullOrEmpty(Convert.ToString(command.Id)) || command.Id == 0)
                {
                    _context.podDetails.Add(pod);
                }
                else
                {
                    PodDetails dbModel = _context.podDetails.Where(m => m.Id == command.Id).FirstOrDefault();
                    dbModel.PODName = command.PODName;
                    dbModel.BubbleAdded = command.BubbleAdded;
                    dbModel.DistributionCount = command.DistributionCount;
                    dbModel.IsAllowtoEdit = command.IsAllowtoEdit;
                    dbModel.IsCreateMeet = command.IsCreateMeet;
                    dbModel.CreatedBy = command.CreatedBy;
                    dbModel.UpdatedBy = command.UpdatedBy;
                    dbModel.BubbleId = command.BubbleId;
                    dbModel.IsDelete = command.IsDelete;

                }
                await _context.SaveChanges();
                return command.Id;

            }
        }
    }
}
