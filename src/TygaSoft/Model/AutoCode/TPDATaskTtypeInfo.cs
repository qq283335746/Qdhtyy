using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDATaskTtypeInfo
    {
        public TPDATaskTtypeInfo() { }

        public TPDATaskTtypeInfo(string tID, string tname)
        {
            this.TID = tID;
            this.Tname = tname;
        }

        public string TID { get; set; }
        public string Tname { get; set; }
    }
}
