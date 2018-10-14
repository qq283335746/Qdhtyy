using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDAPDAlistInfo
    {
        public TPDAPDAlistInfo() { }

        public TPDAPDAlistInfo(string pNO, string pID, string pCNO, string pCID, string pstate, string poper, DateTime popTime)
        {
            this.PNO = pNO;
            this.PID = pID;
            this.PCNO = pCNO;
            this.PCID = pCID;
            this.Pstate = pstate;
            this.Poper = poper;
            this.PopTime = popTime;
        }

        public string PNO { get; set; }
        public string PID { get; set; }
        public string PCNO { get; set; }
        public string PCID { get; set; }
        public string Pstate { get; set; }
        public string Poper { get; set; }
        public DateTime PopTime { get; set; }
    }
}
