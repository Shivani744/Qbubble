using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using Application.Interfaces;

namespace Application.Features.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhoneNo { get; set; }
        public string ZipCode { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Longitute { get; set; }
        public string Latitude { get; set; }
        public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = _context.userDetails.Where(u => u.Id == command.Id).FirstOrDefault();
                if (user == null)
                {
                    return default;
                }
                else
                {
                    user.Username = command.Username;
                    user.PhoneNo = command.PhoneNo;
                    user.ZipCode = command.ZipCode;
                    user.CreatedBy = command.CreatedBy;
                    user.UpdatedBy = command.UpdatedBy;
                    user.ProfilePicUrl = command.ProfilePicUrl;
                    user.Longitute = command.Longitute;
                    user.Latitude = command.Latitude;
                    await _context.SaveChanges();
                    return user.Id;
                }
            }
        }
    }
}
