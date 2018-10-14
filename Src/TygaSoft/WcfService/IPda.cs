using System;
using System.ServiceModel;
using TygaSoft.WcfModel;

namespace TygaSoft.WcfService
{
    [ServiceContract(Namespace = "http://TygaSoft.Services.PdaService")]
    public interface IPda
    {
        [OperationContract(Name = "GetHelloWord")]
        string GetHelloWord();

        [OperationContract(Name = "ValidateUser")]
        string ValidateUser(string pid, string pno, string username, string password);

        [OperationContract(Name = "GetAuthInfo")]
        string GetAuthInfo(string pid, string pno, string emp);

        [OperationContract(Name = "GetTaskList")]
        string GetTaskList(string pid, string pno);

        [OperationContract(Name = "GetBoxList")]
        string GetBoxList(string pno, string bno);

        [OperationContract(Name = "GetFeeQ")]
        string GetFeeQ(string amon, string btype, string pno, string bno);

        [OperationContract(Name = "GetInQTask")]
        string GetInQTask(string pid, string pno, string adate);

        [OperationContract(Name = "GetEtask")]
        string GetEtask(string pid, string pno, string adate, string uid);

        [OperationContract(Name = "GetEmpTlist")]
        string GetEmpTlist(string pno, string mon, string uid);

        [OperationContract(Name = "SaveTaskInfo")]
        string SaveTaskInfo(string cid, string adate, string rno, string bno, string stime, string etime, int kilm, int fee, string oper);

        [OperationContract(Name = "SaveBatchTaskCargoInfo")]
        string SaveBatchTaskCargoInfo(string pno, string oper, string rno, string bno, string boxno, string tocid, string tobno, string otype, string odate);

        [OperationContract(Name = "SaveTaskCargoInfo")]
        string SaveTaskCargoInfo(string pno, string oper, string bno, string boxno, string tocid, string tobno, string btype);

        [OperationContract(Name = "SaveBoxInfo")]
        string SaveBoxInfo(string pno, string bno, string oper, string boxno, string btype, string pdate, string tocid, string tobno);

        [OperationContract(Name = "SaveApplyTaskInfo")]
        string SaveApplyTaskInfo(string adate, string pno, string bno, string oper, string ptime, string note);

        [OperationContract(Name = "SaveETask")]
        string SaveETask(string oper, string pno, string bno, string rno, string adate, string stime, string etime, int kilm, int fee, string eva);
    }
}
