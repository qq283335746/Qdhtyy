using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDATaskBankInfo
    {
        public TPDATaskBankInfo() { }

        public TPDATaskBankInfo(string tBcid, string tBdate, string tBRno, string tBBNO, string tBBname, string tBPtime, int tBboxNum, string tBnotes, string tBoper, DateTime tBopTime, string tBState, string tBType, string tBStime, string tBEtime, decimal tBTlen, int tBKilM, int tBFee, int tBWxs, string tBEmp, string tBCNO)
        {
            this.TBcid = tBcid;
            this.TBdate = tBdate;
            this.TBRno = tBRno;
            this.TBBNO = tBBNO;
            this.TBBname = tBBname;
            this.TBPtime = tBPtime;
            this.TBboxNum = tBboxNum;
            this.TBnotes = tBnotes;
            this.TBoper = tBoper;
            this.TBopTime = tBopTime;
            this.TBState = tBState;
            this.TBType = tBType;
            this.TBStime = tBStime;
            this.TBEtime = tBEtime;
            this.TBTlen = tBTlen;
            this.TBKilM = tBKilM;
            this.TBFee = tBFee;
            this.TBWxs = tBWxs;
            this.TBEmp = tBEmp;
            this.TBCNO = tBCNO;
        }

        public string TBcid { get; set; }
        public string TBdate { get; set; }
        public string TBRno { get; set; }
        public string TBBNO { get; set; }
        public string TBBname { get; set; }
        public string TBPtime { get; set; }
        public int TBboxNum { get; set; }
        public string TBnotes { get; set; }
        public string TBoper { get; set; }
        public DateTime TBopTime { get; set; }
        public string TBState { get; set; }
        public string TBType { get; set; }
        public string TBStime { get; set; }
        public string TBEtime { get; set; }
        public decimal TBTlen { get; set; }
        public int TBKilM { get; set; }
        public int TBFee { get; set; }
        public int TBWxs { get; set; }
        public string TBEmp { get; set; }
        public string TBCNO { get; set; }
    }
}
