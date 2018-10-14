using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDATaskBoxInfo
    {
        public TPDATaskBoxInfo() { }

        public TPDATaskBoxInfo(string tBCID, string tBDate, string tBRNO, string tBBNO, string tBBname, string tBBoxNO, string tBBoxC0, string tBBoxC1, string tBInOut, string tBToCID, string tBToBno, string tBToBname, string tBOtype, string tBPdate, string tBState)
        {
            this.TBCID = tBCID;
            this.TBDate = tBDate;
            this.TBRNO = tBRNO;
            this.TBBNO = tBBNO;
            this.TBBname = tBBname;
            this.TBBoxNO = tBBoxNO;
            this.TBBoxC0 = tBBoxC0;
            this.TBBoxC1 = tBBoxC1;
            this.TBInOut = tBInOut;
            this.TBToCID = tBToCID;
            this.TBToBno = tBToBno;
            this.TBToBname = tBToBname;
            this.TBOtype = tBOtype;
            this.TBPdate = tBPdate;
            this.TBState = tBState;
        }

        public string TBCID { get; set; }
        public string TBDate { get; set; }
        public string TBRNO { get; set; }
        public string TBBNO { get; set; }
        public string TBBname { get; set; }
        public string TBBoxNO { get; set; }
        public string TBBoxC0 { get; set; }
        public string TBBoxC1 { get; set; }
        public string TBInOut { get; set; }
        public string TBToCID { get; set; }
        public string TBToBno { get; set; }
        public string TBToBname { get; set; }
        public string TBOtype { get; set; }
        public string TBPdate { get; set; }
        public string TBState { get; set; }
    }
}
