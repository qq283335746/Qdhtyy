package com.tygasoft.services;

import java.util.LinkedHashMap;
import java.util.Map;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.tygasoft.utility.ResResult;

public class QdhtyyService implements IQdhtyy {
	//public static String Url = "http://www.tygaweb.com/Qdhtyy/Services/PdaService.svc";
	public static String Url = "http://120.26.198.137/Qdhtyy/Services/PdaService.svc";
	private static final String NameSpace = "http://TygaSoft.Services.PdaService";
    private static final String SoapAction = NameSpace + "/IPda/";
    
	public String GetHelloWord() {
		return GetResult("GetHelloWord",null);
    }
	
	public String ValidateUser(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pid", jsonObj.get("DeviceId").getAsString());
		items.put("pno", jsonObj.get("DeviceCode").getAsString());
		items.put("username", jsonObj.get("UserName").getAsString());
		items.put("password", jsonObj.get("Password").getAsString());

		return GetResult("ValidateUser",items);
    }
	
	public String GetAuthInfo(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pid", jsonObj.get("DeviceId").getAsString());
		items.put("pno", jsonObj.get("DeviceCode").getAsString());
		items.put("eid", jsonObj.get("NfcCode").getAsString());

		return GetResult("GetAuthInfo",items);
    }
	
	public String GetTaskList(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pid", jsonObj.get("DeviceId").getAsString());
		items.put("pno", jsonObj.get("DeviceCode").getAsString());

		return GetResult("GetTaskList",items);
    }
	
	public String GetBoxList(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("bno", jsonObj.get("Bno").getAsString());

		return GetResult("GetBoxList",items);
    }
	
	public String GetFeeQ(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("amon", jsonObj.get("Amon").getAsString());
		items.put("btype", jsonObj.get("Btype").getAsString());
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("bno", jsonObj.get("Bno").getAsString());

		return GetResult("GetFeeQ",items);
    }
	
	public String GetInQTask(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pid", jsonObj.get("Pid").getAsString());
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("adate", "");

		return GetResult("GetInQTask",items);
    }
	
	public String GetEtask(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pid", jsonObj.get("DeviceId").getAsString());
		items.put("pno", jsonObj.get("DeviceCode").getAsString());
		items.put("uid", jsonObj.get("Uid").getAsString());
		items.put("adate", "");

		return GetResult("GetEtask",items);
    }
	
	public String GetEmpTlist(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pno", jsonObj.get("DeviceCode").getAsString());
		items.put("mon", jsonObj.get("YMonth").getAsString());
		items.put("uid", jsonObj.get("Uid").getAsString());

		return GetResult("GetEmpTlist",items);
    }
	
	public String SaveTaskInfo(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("cid", jsonObj.get("CId").getAsString());
		items.put("adate", jsonObj.get("Adate").getAsString());
		items.put("rno", jsonObj.get("RNO").getAsString());
		items.put("bno", jsonObj.get("BNO").getAsString());
		items.put("stime", jsonObj.get("Stime").getAsString());
		items.put("etime", jsonObj.get("Etime").getAsString());
		items.put("kilm", jsonObj.get("Kilm").getAsInt());
		items.put("fee", jsonObj.get("Fee").getAsInt());
		items.put("oper", jsonObj.get("Oper").getAsString());

		return GetResult("SaveTaskInfo",items);
    }
	
	public String SaveBatchTaskCargoInfo(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("oper", jsonObj.get("Oper").getAsString());
		items.put("rno", jsonObj.get("Rno").getAsString());
		items.put("bno", jsonObj.get("Bno").getAsString());
		items.put("boxno", jsonObj.get("BoxNo").getAsString());
		items.put("tocid", jsonObj.get("ToCid").getAsString());
		items.put("tobno", jsonObj.get("ToBno").getAsString());
		items.put("otype", jsonObj.get("Otype").getAsString());
		items.put("odate", jsonObj.get("Odate").getAsString());

		return GetResult("SaveBatchTaskCargoInfo",items);
    }
	
	public String SaveTaskCargoInfo(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("oper", jsonObj.get("Oper").getAsString());
		items.put("bno", jsonObj.get("Bno").getAsString());
		items.put("boxno", jsonObj.get("BoxNo").getAsString());
		items.put("tocid", jsonObj.get("ToCid").getAsString());
		items.put("tobno", jsonObj.get("ToBno").getAsString());
		items.put("btype", jsonObj.get("Btype").getAsString());

		return GetResult("SaveTaskCargoInfo",items);
    }
	
	public String SaveBoxInfo(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("bno", jsonObj.get("Bno").getAsString());
		items.put("oper", jsonObj.get("Oper").getAsString());
		items.put("boxno", jsonObj.get("BoxNo").getAsString());
		items.put("btype", jsonObj.get("Btype").getAsString());
		items.put("pdate", jsonObj.get("Pdate").getAsString());
		items.put("tocid", jsonObj.get("ToCid").getAsString());
		items.put("tobno", jsonObj.get("ToBno").getAsString());

		return GetResult("SaveBoxInfo",items);
    }
	
	public String SaveApplyTaskInfo(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("adate", jsonObj.get("Adate").getAsString());
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("bno", jsonObj.get("Bno").getAsString());
		items.put("oper", jsonObj.get("Oper").getAsString());
		items.put("ptime", jsonObj.get("Ptime").getAsString());
		items.put("note", jsonObj.get("Note").getAsString());

		return GetResult("SaveApplyTaskInfo",items);
    }
	
	public String SaveETask(String jsonField) {
		Gson gson = new Gson();
		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
		LinkedHashMap<String, Object> items = new LinkedHashMap<String, Object>();
		items.put("oper", jsonObj.get("Oper").getAsString());
		items.put("pno", jsonObj.get("Pno").getAsString());
		items.put("bno", jsonObj.get("Bno").getAsString());
		items.put("rno", jsonObj.get("Rno").getAsString());
		items.put("adate", "");
		items.put("stime", jsonObj.get("Stime").getAsString());
		items.put("etime", jsonObj.get("Etime").getAsString());
		items.put("kilm", jsonObj.get("Kilm").getAsInt());
		items.put("fee", jsonObj.get("Fee").getAsInt());
		items.put("eva", jsonObj.get("Eva").getAsString());

		return GetResult("SaveETask",items);
    }
	
	private String GetResult(String method,LinkedHashMap<String, Object> items){
		SoapObject soapObject = new SoapObject(NameSpace, method);
		if(items != null && items.size()>0){
			for (Map.Entry<String, Object> entry : items.entrySet()) {
				soapObject.addProperty(entry.getKey(), entry.getValue().toString());
			}
		}
        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11); // °æ±¾
        envelope.bodyOut = soapObject;
        envelope.dotNet = true;
        envelope.setOutputSoapObject(soapObject);
        
        HttpTransportSE trans = new HttpTransportSE(Url);
        trans.debug = false;
        SoapObject result = null;
        try {
            trans.call(SoapAction+method, envelope);
            result = (SoapObject)envelope.bodyIn;
            if(result != null) return result.getProperty(0).toString();
            else return ResResult.ResJsonString(false, "Request Error...", "");
        } 
        catch (Exception ex) {
        	return ResResult.ResJsonString(false, ex.getMessage(), "");
        }
	}  
}
