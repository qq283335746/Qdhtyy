using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TygaSoft.SysException;
using TygaSoft.SysHelper;
using TygaSoft.BLL;
using TygaSoft.Model;
using TygaSoft.WcfModel;

namespace TygaSoft.WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PdaService : IPda
    {
        public string GetHelloWord()
        {
            return ResResult.ResJsonString(true, "", "Hello Word");
        }

        public string ValidateUser(string pid, string pno, string username, string password)
        {
            try
            {
                new CustomException(string.Format("{0}--pid：{1}，pno：{2}，username：{3}，password：{4}", "ValidateUser", pid, pno, username, password));

                var bll = new TPDAUser();
                if (!bll.ValidateUser(username, password, pid, pno)) return ResResult.ResJsonString(false, MC.Login_InvalidAccount, "");
                return ResResult.ResJsonString(true, "", bll.GetModel(username, password));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string GetAuthInfo(string pid, string pno, string eid)
        {
            try
            {
                new CustomException(string.Format("{0}--pid：{1}，pno：{2}，eid：{3}", "GetAuthInfo", pid, pno, eid));
                var bll = new TPDATaskBank();
                return ResResult.ResJsonString(true, "", bll.GetAuthInfo(pid, pno, eid, DateTime.Now.ToString("yyyy-MM-dd")));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string GetTaskList(string pid, string pno)
        {
            try
            {
                new CustomException(string.Format("GetTaskList--pid：{0}，pno：{1}", pid, pno));

                var bll = new TPDATaskBank();
                return ResResult.ResJsonString(true, "", JsonConvert.SerializeObject(bll.GetList(pid, pno, DateTime.Now.ToString("yyyy-MM-dd"))));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string GetBoxList(string pno, string bno)
        {
            try
            {
                new CustomException(string.Format("GetBoxList--pno：{0}，bno：{1}", pno, bno));

                var bll = new TPDABOX();
                return ResResult.ResJsonString(true, "", JsonConvert.SerializeObject(bll.GetBoxs(pno, bno)));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string GetFeeQ(string amon, string btype, string pno, string bno)
        {
            try
            {
                new CustomException(string.Format("GetFeeQ--amon：{0}，btype：{1}，pno：{2}，bno：{3}", amon, btype, pno, bno));

                var bll = new TPDABankFEE();
                return ResResult.ResJsonString(true, "", JsonConvert.SerializeObject(bll.GetFeeQ(amon, btype, pno, bno)));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string GetInQTask(string pid, string pno, string adate)
        {
            try
            {
                new CustomException(string.Format("GetInQTask--pid：{0}，pno：{1}，adate：{2}", pid, pno, adate));

                if (string.IsNullOrEmpty(adate) || string.IsNullOrEmpty(adate.Trim())) adate = DateTime.Now.ToString("yyyy-MM-dd");

                var bll = new TPDATaskBank();
                return ResResult.ResJsonString(true, "", JsonConvert.SerializeObject(bll.GetInQTask(pid, pno, adate)));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string GetEtask(string pid, string pno, string adate, string uid)
        {
            try
            {
                new CustomException(string.Format("GetEtask--pid：{0}，pno：{1}，adate：{2}，uid：{3}", pid, pno, adate,uid));
                if (string.IsNullOrWhiteSpace(adate)) adate = DateTime.Now.ToString("yyyy-MM-dd");

                var bll = new TPDATaskEbank();
                return ResResult.ResJsonString(true, "", bll.GetEtask(pid, pno, adate, uid));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string GetEmpTlist(string pno, string mon, string uid)
        {
            try
            {
                new CustomException(string.Format("GetEmpTlist--pno：{0}，mon：{1}，uid：{2}", pno, mon, uid));
                if (string.IsNullOrWhiteSpace(mon)) mon = DateTime.Now.ToString("yyyy-MM");

                var bll = new TPDATaskEbank();
                return ResResult.ResJsonString(true, "", bll.GetEmpTlist(pno, mon, uid));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string SaveTaskInfo(string cid, string adate, string rno, string bno, string stime, string etime, int kilm, int fee, string oper)
        {
            try
            {
                new CustomException(string.Format("SaveTaskInfo--cid：{0}，adate：{1}，rno：{2}，bno：{3}，stime：{4}，etime：{5}，kilm：{6}，fee：{7}，oper：{8}", cid, adate, rno, bno, stime, etime, kilm, fee, oper));

                var bll = new TPDATaskBank();
                int effect = bll.SaveTaskInfo(cid, adate, rno, bno, stime, etime, kilm, fee, oper);
                if (effect > 0) return ResResult.ResJsonString(true, "", "");

                return ResResult.ResJsonString(false, MC.M_Save_Error, "");
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string SaveBatchTaskCargoInfo(string pno, string oper, string rno, string bno, string boxno, string tocid, string tobno, string otype, string odate)
        {
            try
            {
                new CustomException(string.Format("SaveBatchTaskCargoInfo--pno：{0}，oper：{1}，rno：{2}，bno：{3}，boxno：{4}，tocid：{5}，tobno：{6}，otype：{7}，odate：{8}", pno, oper, rno, bno, boxno, tocid, tobno, otype, odate));
                string otypeIndex = "0";
                if (!string.IsNullOrWhiteSpace(otype)) otypeIndex = EnumHelper.GetValue(typeof(EnumData.OType), otype).ToString();
                var date = DateTime.Parse("1754-01-01");
                DateTime.TryParse(odate, out date);

                var bll = new TPDATaskBank();
                var currTime = DateTime.Now.ToString("yyyy-MM-dd");
                int effect = bll.SaveBatchTaskCargoInfo(currTime, pno, oper, rno, bno, boxno, tocid, tobno, otypeIndex, date.ToString("yyyy-MM-dd"), currTime);
                if (effect > 0) return ResResult.ResJsonString(true, "", "");

                return ResResult.ResJsonString(false, MC.M_Save_Error, "");
            }
            catch (Exception ex)
            {
                new CustomException("SaveBatchTaskCargoInfo--", ex);
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string SaveTaskCargoInfo(string pno, string oper, string bno, string boxno, string tocid, string tobno, string btype)
        {
            try
            {
                new CustomException(string.Format("SaveTaskCargoInfo--pno：{0}，oper：{1}，bno：{2}，boxno：{3}，tocid：{4}，tobno：{5}，otype：{6}", pno, oper, bno, boxno, tocid, tobno, btype));

                var bll = new TPDATaskBank();
                var currTime = DateTime.Now.ToString("yyyy-MM-dd");
                int effect = bll.SaveTaskCargoInfo(pno, oper, bno, boxno, tocid, tobno, btype, currTime);
                if (effect > 0) return ResResult.ResJsonString(true, "", "");

                return ResResult.ResJsonString(false, MC.M_Save_Error, "");
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string SaveBoxInfo(string pno,string bno,string oper,string boxno,string btype,string pdate,string tocid,string tobno)
        {
            try
            {
                new CustomException(string.Format("SaveBoxInfo--pno：{0}，bno：{1}，oper：{2}，boxno：{3}，btype：{4}，pdate：{5}，tocid：{6}，tobno：{7}", pno, bno, oper, boxno, btype, pdate, tocid, tobno));

                var bll = new TPDABOX();
                return ResResult.ResJsonString(true, "", JsonConvert.SerializeObject(bll.SaveBoxInfo(pno,bno,oper,boxno,btype,pdate,tocid,tobno)));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string SaveApplyTaskInfo(string adate, string pno, string bno, string oper, string ptime, string note)
        {
            try
            {
                new CustomException(string.Format("SaveApplyTaskInfo--adate：{0}，pno：{1}，bno：{2}，oper：{3}，ptime：{4}，note：{5}", adate,pno, bno, oper, ptime, note));

                if (string.IsNullOrWhiteSpace(adate)) adate = DateTime.Now.ToString("yyyy-MM-dd");
                var bll = new TPDATaskBank();
                return ResResult.ResJsonString(true, "", JsonConvert.SerializeObject(bll.SaveApplyTaskInfo(adate,pno, bno, oper, ptime, note)));
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }

        public string SaveETask(string oper, string pno, string bno, string rno, string adate, string stime, string etime, int kilm, int fee, string eva)
        {
            try
            {
                new CustomException(string.Format("SaveETask--oper：{0}，pno：{1}，bno：{2}，rno：{3}，adate：{4}，stime：{5}，etime：{6}，kilm：{7}，fee：{8}，eva：{9}", oper, pno, bno, rno, adate,stime, etime, kilm, fee, eva));

                if (string.IsNullOrWhiteSpace(adate)) adate = DateTime.Now.ToString("yyyy-MM-dd");
                var bll = new TPDATaskEbank();
                int effect = bll.SaveETask(oper, bno, bno, rno, adate, stime, etime, kilm, fee, eva);
                if(effect < 1) return ResResult.ResJsonString(false, MC.M_Save_Error, "");
                return ResResult.ResJsonString(true, "", "");
            }
            catch (Exception ex)
            {
                return ResResult.ResJsonString(false, ex.Message, "");
            }
        }
    }
}
