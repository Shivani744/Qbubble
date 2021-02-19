using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Common;


namespace Domain.Entities
{
    public class PodDetails : BaseEntity
    {
        public PodDetails()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
        }
        public string PODName { get; set; }
        public bool IsCreateMeet { get; set; }
        public bool IsAllowtoEdit { get; set; }
        public bool IsDelete { get; set; }
        public string DistributionCount { get; set; }
        public string BubbleAdded { get; set; }
        public int BubbleId { get; set; }
        [ForeignKey("BubbleId")]
        public BubbleDetails BubbleDetails { get; set; }

    }
}
