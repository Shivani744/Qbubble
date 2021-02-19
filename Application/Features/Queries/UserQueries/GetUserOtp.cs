using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.UserQueries
{
   public class GetUserOtp : IRequest<OtpHistory>
    {
        public string Otp { get; set; }
        public class GetUserOtpHandler : IRequestHandler<GetUserOtp, OtpHistory>
        {
            private readonly IApplicationDbContext _context;
            public GetUserOtpHandler(IApplicationDbContext context) => _context = context;

            public async Task<OtpHistory> Handle(GetUserOtp query, CancellationToken cancellationToken)
            {
                var objOtp = _context.otpHistory.Where(a => a.Otp == query.Otp && a.OtpTimeStamp>DateTime.Now.AddMinutes(-1)).FirstOrDefault();
                if (objOtp == null)
                {
                    var objOtp2 = _context.otpHistory.Where(a => a.Otp == query.Otp && a.OtpStatus==true).FirstOrDefault();
                    objOtp2.OtpStatus = false;
                    await _context.SaveChanges();
                    return null;
                }
                return objOtp;
            }
        }
    }
}
