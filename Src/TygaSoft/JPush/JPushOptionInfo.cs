using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TygaSoft.JPush
{
    public class JPushOptionInfo
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Alias { get; set; }

        public EnumPushPayloadType PushPayloadType { get; set; }
    }
}
