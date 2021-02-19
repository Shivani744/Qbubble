﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class BubbleMembers : BaseEntity
    {
        public BubbleMembers()
        {
            UpdatedOn = DateTime.UtcNow;
            CreatedOn = DateTime.UtcNow;
        }
        public int BubbleId { get; set; }
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public UserDetails UserDetails { get; set; }

        [ForeignKey("BubbleId")]
        public BubbleDetails BubbleDetails { get; set; }
    }
}
