using System;

namespace TygaSoft.Model
{
    [Serializable]
    public partial class TPDABOXInfo
    {
        public TPDABOXInfo() { }

        public TPDABOXInfo(string boxCID, string boxNo, string boxBno, string boxType, string boxPdate, string boxScid, string boxSbno, string boxCstate, string boxDcid, string boxDBno, string boxOper, DateTime boxOpTime, string boxState)
        {
            this.BoxCID = boxCID;
            this.BoxNo = boxNo;
            this.BoxBno = boxBno;
            this.BoxType = boxType;
            this.BoxPdate = boxPdate;
            this.BoxScid = boxScid;
            this.BoxSbno = boxSbno;
            this.BoxCstate = boxCstate;
            this.BoxDcid = boxDcid;
            this.BoxDBno = boxDBno;
            this.BoxOper = boxOper;
            this.BoxOpTime = boxOpTime;
            this.BoxState = boxState;
        }

        public string BoxCID { get; set; }
        public string BoxNo { get; set; }
        public string BoxBno { get; set; }
        public string BoxType { get; set; }
        public string BoxPdate { get; set; }
        public string BoxScid { get; set; }
        public string BoxSbno { get; set; }
        public string BoxCstate { get; set; }
        public string BoxDcid { get; set; }
        public string BoxDBno { get; set; }
        public string BoxOper { get; set; }
        public DateTime BoxOpTime { get; set; }
        public string BoxState { get; set; }
    }
}
