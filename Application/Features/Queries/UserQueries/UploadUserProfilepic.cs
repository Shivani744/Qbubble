using MediatR;
using Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using System.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Queries.UserQueries
{
    public class UploadUserProfilepic : IRequest<string>
    {

        public string ImageUrl { get; set; }
        public int Id { get; set; }
        public class UploadUserProfilepicHandler : IRequestHandler<UploadUserProfilepic, string>
        {
            private readonly IHostingEnvironment _appEnvironment;
            private readonly IApplicationDbContext _context;
            public UploadUserProfilepicHandler(IApplicationDbContext context, IHostingEnvironment appEnvironment)
            {
                _context = context;
                _appEnvironment = appEnvironment;
            }


            public async Task<string> Handle(UploadUserProfilepic query, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(query.ImageUrl) && query.Id > 0)
                {
                    var userData = _context.userDetails.Where(x => x.Id == query.Id).FirstOrDefault();
                    userData.ProfilePicUrl = query.ImageUrl;
                  await  _context.SaveChanges();
                    
                }
                return query.ImageUrl;
            }
        }
    }
}







