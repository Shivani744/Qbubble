using System;
using System.Collections.Generic;
using System.Text;
using static Domain.CommonCodes.CommonEnums;

namespace Application.ApiModels
{
   public class BubbleApiModel:BaseApiModel
    {
        public string BubbleName { get; set; }
        public string BubbleSize { get; set; }
        public string BubbleDescription { get; set; }
        public string BubbleZipCode { get; set; }
        public BubbleType BubbleType { get; set; }
        public DateTime BubbleValidity { get; set; }
        public bool IsOtherCountyMemberAllowed { get; set; }
    }
}
