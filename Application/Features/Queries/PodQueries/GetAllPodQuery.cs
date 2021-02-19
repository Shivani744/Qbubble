using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.Queries.PodQueries
{

    public class GetAllPodQuery : IRequest<IEnumerable<PodDetails>>
    {
        public class GetAllPodQueriesHandler : IRequestHandler<GetAllPodQuery, IEnumerable<PodDetails>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPodQueriesHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<PodDetails>> Handle(GetAllPodQuery query, CancellationToken cancellationToken)
            {
                var podList = await _context.podDetails.ToListAsync();
                if (podList == null)
                {
                    return default;
                }
                return podList.AsReadOnly();
            }
        }
    }
}
