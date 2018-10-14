package com.tygasoft.services;

public interface IQdhtyy {
	
	String GetHelloWord();
	
	String ValidateUser(String jsonField);
	
	String GetAuthInfo(String jsonField);
	
	String GetTaskList(String jsonField);
	
	String GetBoxList(String jsonField);
	
	String GetFeeQ(String jsonField);
	
	String GetInQTask(String jsonField);
	
	String GetEtask(String jsonField);
	
	String GetEmpTlist(String jsonField);
	
	String SaveTaskInfo(String jsonField);
	
	String SaveBoxInfo(String jsonField);
	
	String SaveBatchTaskCargoInfo(String jsonField);
	
	String SaveTaskCargoInfo(String jsonField);
	
	String SaveApplyTaskInfo(String jsonField);
	
	String SaveETask(String jsonField);
}
