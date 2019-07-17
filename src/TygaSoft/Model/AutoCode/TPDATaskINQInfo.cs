using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDATaskINQInfo
    {
        public TPDATaskINQInfo() { }

        public TPDATaskINQInfo(int tKIID, string tKdate, string tKBNO, string tKBname, string tKPdate, string tKNote, string tKPNO, string tKoper, DateTime tKopTime, string tKState, string tKRno, string tKCoper, DateTime tKCopTime)
        {
            this.TKIID = tKIID;
            this.TKdate = tKdate;
            this.TKBNO = tKBNO;
            this.TKBname = tKBname;
            this.TKPdate = tKPdate;
            this.TKNote = tKNote;
            this.TKPNO = tKPNO;
            this.TKoper = tKoper;
            this.TKopTime = tKopTime;
            this.TKState = tKState;
            this.TKRno = tKRno;
            this.TKCoper = tKCoper;
            this.TKCopTime = tKCopTime;
        }

        public int TKIID { get; set; }
        public string TKdate { get; set; }
        public string TKBNO { get; set; }
        public string TKBname { get; set; }
        public string TKPdate { get; set; }
        public string TKNote { get; set; }
        public string TKPNO { get; set; }
        public string TKoper { get; set; }
        public DateTime TKopTime { get; set; }
        public string TKState { get; set; }
        public string TKRno { get; set; }
        public string TKCoper { get; set; }
        public DateTime TKCopTime { get; set; }
    }
}
