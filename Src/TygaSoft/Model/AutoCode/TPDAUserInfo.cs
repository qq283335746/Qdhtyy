using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDAUserInfo
    {
        public TPDAUserInfo() { }

        public TPDAUserInfo(string uID, string uname, string ucNO, string upda, string upwd, string uoper, DateTime uopTime, string ustate, string utype)
        {
            this.UID = uID;
            this.Uname = uname;
            this.UcNO = ucNO;
            this.Upda = upda;
            this.Upwd = upwd;
            this.Uoper = uoper;
            this.UopTime = uopTime;
            this.Ustate = ustate;
            this.Utype = utype;
        }

        public string UID { get; set; }
        public string Uname { get; set; }
        public string UcNO { get; set; }
        public string Upda { get; set; }
        public string Upwd { get; set; }
        public string Uoper { get; set; }
        public DateTime UopTime { get; set; }
        public string Ustate { get; set; }
        public string Utype { get; set; }
    }
}
