using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserDetails> userDetails { get; set; }
        DbSet<OtpHistory> otpHistory { get; set; }
        DbSet<BubbleDetails> bubbleDetails { get; set; }
        DbSet<BubbleMeetDetails> bubbleMeetDetails { get; set; }
        DbSet<PodDetails> podDetails { get; set; }
        DbSet<BubbleMembers> bubbleMembers { get; set; }

        Task<int> SaveChanges();
    }
}