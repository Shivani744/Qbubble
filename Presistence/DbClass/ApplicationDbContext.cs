using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.DbClass
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<OtpHistory> otpHistory { get; set; }
        public DbSet<BubbleDetails> bubbleDetails { get; set; }
        public DbSet<BubbleMeetDetails> bubbleMeetDetails { get; set; }
        public DbSet<PodDetails> podDetails { get; set; }
        public DbSet<BubbleMembers> bubbleMembers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
