using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDABankFEEInfo
    {
        public TPDABankFEEInfo() { }

        public TPDABankFEEInfo(string tBcid, string tBdate, string tBBNO, string tBBname, string tBFName, string tBnotes, string tBoper, DateTime tBopTime, int tBFee)
        {
            this.TBcid = tBcid;
            this.TBdate = tBdate;
            this.TBBNO = tBBNO;
            this.TBBname = tBBname;
            this.TBFName = tBFName;
            this.TBnotes = tBnotes;
            this.TBoper = tBoper;
            this.TBopTime = tBopTime;
            this.TBFee = tBFee;
        }

        public string TBcid { get; set; }
        public string TBdate { get; set; }
        public string TBBNO { get; set; }
        public string TBBname { get; set; }
        public string TBFName { get; set; }
        public string TBnotes { get; set; }
        public string TBoper { get; set; }
        public DateTime TBopTime { get; set; }
        public int TBFee { get; set; }
    }
}
