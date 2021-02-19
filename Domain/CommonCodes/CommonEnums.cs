using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.CommonCodes
{
   public class CommonEnums
    {
        public enum BubbleType
        {
            Single = 1,
            Multi = 2
        }

        public enum UserPermission
        {
            NoAccess = 0,
            FullAccess =1,
            CanEdit=2
        }
    }
}
