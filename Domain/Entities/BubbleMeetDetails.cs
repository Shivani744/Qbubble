using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Common;
using static Domain.CommonCodes.CommonEnums;


namespace Domain.Entities
{
    public class BubbleMeetDetails : BaseEntity
    {
        public BubbleMeetDetails()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
        }
        public string Title { get; set; }
     
        public string MeetDescription { get; set; }
        public DateTime MeetTiming { get; set; }
        public string MeetPlace { get; set; }
        public string ZipCode { get; set; }
        public bool AllowChat { get; set; }
        public UserPermission UserPermission { get; set; }
        public int BubbleId { get; set; }
        [ForeignKey("BubbleId")]
        public BubbleDetails BubbleDetails { get; set; }


    }
}
