using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Features.Commands.UserCommands
{
   public class CreateUserCommand :IRequest<int>
    {
        public string Username { get; set; }
        public string PhoneNo { get; set; }
        public string ZipCode { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string Longitute { get; set; }
        public string Latitude { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new UserDetails();
                user.Username = command.Username;
                user.PhoneNo = command.PhoneNo;
                user.ZipCode = command.ZipCode;
                user.CreatedBy = command.CreatedBy;
                user.UpdatedBy = command.UpdatedBy;
                user.Longitute = command.Longitute;
                user.Latitude = command.Latitude;
                _context.userDetails.Add(user);
                await _context.SaveChanges();
                return user.Id;
            }

        }

    }
}
