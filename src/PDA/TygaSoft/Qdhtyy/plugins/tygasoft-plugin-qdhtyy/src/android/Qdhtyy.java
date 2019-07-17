package com.tygasoft.bll;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import android.database.Cursor;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonObject;
import com.tygasoft.dbutility.QdhtyySqliteHelper;
import com.tygasoft.services.QdhtyyService;
import com.tygasoft.utility.ResResult;

public class Qdhtyy {
	
	QdhtyySqliteHelper dbHelper;
	
	public Qdhtyy(){}
	public Qdhtyy(QdhtyySqliteHelper dbHelper){
		this.dbHelper = dbHelper;
	}
	
    public String InsertBarcode(String jsonField){
    	Cursor res = null;
    	try{
        	Gson gson = new GsonBuilder().disableHtmlEscaping().create();  
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		String sId = jsonObj.get("Id").getAsString();
    		String sBarcode = jsonObj.get("Barcode").getAsString();
    		String sParentId = jsonObj.get("ParentId").getAsString();
    		String sContentValue = jsonObj.get("ContentValue").getAsString();
    		String sTypeName = jsonObj.get("TypeName").getAsString();
    		SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");       
    		Date currTime = new Date(System.currentTimeMillis());
    		String sLastUpdatedDate = formatter.format(currTime);
    		
    		Map<String, Object> items = new HashMap<String, Object>();
    		items.put("Barcode", sBarcode);
    		items.put("ParentId", sParentId);
    		items.put("ContentValue", sContentValue);
    		items.put("TypeName", sTypeName);
    		items.put("LastUpdatedDate", sLastUpdatedDate);
    		
    		String sqlWhere = "and Barcode = '"+sBarcode+"' and ParentId = '"+sParentId+"' and TypeName = '"+sTypeName+"' ";
    		res = dbHelper.GetSingle("Barcodes", sqlWhere);
        	if(res != null && res.getCount() > 0){
        		if(sId.equals("")) return ResResult.ResJsonString(false, "exist error", "");
        		if(res.moveToNext()){
        			items.put("Id", res.getString(0));
        		}
        		return ResResult.ResJsonString(dbHelper.Update("Barcodes", items), "", "");
        	}
    		else {
        		return ResResult.ResJsonString(dbHelper.Insert("Barcodes", items), "", "");
    		}
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    	finally{
    		if(res != null) res.close();
    	}
    }
    
    public String GetBarcodeList(String jsonField) {
    	Cursor res = null;
    	try{
    		Gson gson = new Gson();
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		String parentId = jsonObj.get("ParentId").getAsString();
    		String typeName = jsonObj.get("TypeName").getAsString();
    		String sqlWhere = "and ParentId = '"+parentId+"' and TypeName = '"+typeName+"' ";
        	StringBuilder sb = new StringBuilder();
        	res = dbHelper.ExecuteReader("Barcodes", sqlWhere);
        	if(res != null && res.getCount() > 0){
        		int index = 0;
        		while(res.moveToNext()){
        			if(index > 0) sb.append(",");
        			sb.append("{\"Id\":\""+res.getInt(0)+"\",\"Barcode\":\""+res.getString(1)+"\",\"ParentId\":\""+res.getString(2)+"\",\"ContentValue\":\""+res.getString(3)+"\",\"TypeName\":\""+res.getString(4)+"\"}");
        			index++;
        		}
        	}
    		
        	return ResResult.ResJsonString(true, "", "["+sb.toString()+"]");
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    	finally{
    		if(res != null) res.close();
    	}
    }
    
    public String GetBarcodeInfo(String jsonField) {
    	Cursor res = null;
    	try{
    		Gson gson = new Gson();
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		String barcode = jsonObj.get("Barcode").getAsString();
    		String parentId = jsonObj.get("ParentId").getAsString();
    		String sqlWhere = "and Barcode = '"+barcode+"' and ParentId = '"+parentId+"' ";
        	StringBuilder sb = new StringBuilder();
        	res = dbHelper.GetSingle("Barcodes", sqlWhere);
        	if(res != null && res.getCount() > 0){
        		while(res.moveToNext()){
        			sb.append("\"Id\":\""+res.getInt(0)+"\",\"Barcode\":\""+res.getString(1)+"\",\"ParentId\":\""+res.getString(2)+"\",\"ContentValue\":\""+res.getString(3)+"\",\"TypeName\":\""+res.getString(4)+"\"");
        		}
        	}
        	return ResResult.ResJsonString(true, "", "{"+sb.toString()+"}");
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    	finally{
    		if(res != null) res.close();
    	}
    }
    
    public String SaveBarcode(String jsonField){
    	try{
    		Map<String, Object> items = new HashMap<String, Object>();
        	Gson gson = new Gson();
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		items.put("Barcode", jsonObj.get("Barcode").getAsString());
    		items.put("ParentId", jsonObj.get("TaskId").getAsString());
    		items.put("ContentValue", jsonObj.get("ContentValue").getAsString());
    		items.put("TypeName", jsonObj.get("TypeName").getAsString());
    		
    		return ResResult.ResJsonString(dbHelper.Insert("Barcodes", items), "", "");
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    }
    
    public String SaveBatchTaskCargo(String jsonField){
    	Cursor res = null;
    	try{
    		Gson gson = new Gson();
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		String pno = jsonObj.get("Pno").getAsString();
    		String rno = jsonObj.get("Rno").getAsString();
    		String bno = jsonObj.get("Bno").getAsString();
    		String oper = jsonObj.get("Oper").getAsString();
    		String parentId = jsonObj.get("ParentId").getAsString();
    		String typeName = jsonObj.get("TypeName").getAsString();
    		
    		String sqlWhere = "and ParentId = '"+parentId+"' and TypeName = '"+typeName+"' ";
    		res = dbHelper.ExecuteReader("Barcodes", sqlWhere);
        	if(res != null && res.getCount() > 0){
        		QdhtyyService client = new QdhtyyService();
        		while(res.moveToNext()){
        			String barcode = res.getString(1);
        			String contentValue = res.getString(3);
        			String sOtype = GetSplitValue(contentValue,"Otype");
        			String sOdate = GetSplitValue(contentValue,"Odate");
        			String sToCid = GetSplitValue(contentValue,"ToCID");
        			String sToBno = GetSplitValue(contentValue,"ToBno");
        			String postData = "{\"Pno\":\""+pno+"\",\"Rno\":\""+rno+"\",\"Bno\":\""+bno+"\",\"BoxNo\":\""+barcode+"\",\"ToCid\":\""+sToCid+"\",\"ToBno\":\""+sToBno+"\",\"Otype\":\""+sOtype+"\",\"Odate\":\""+sOdate+"\",\"Oper\":\""+oper+"\"}";
        			String result = client.SaveBatchTaskCargoInfo(postData);
        			JsonObject resultObj = gson.fromJson(result, JsonObject.class);
        			int resCode = resultObj.get("ResCode").getAsInt();
        			if(resCode == 1000){
        				boolean isDelete = dbHelper.Delete("Barcodes", "and Barcode='"+barcode+"' and ParentId = '"+parentId+"' and TypeName = '"+typeName+"' ");
        				if(!isDelete) return ResResult.ResJsonString(false, "delete error£¡", "");
        			}
        			else return result;
        		}
        	}

    		return ResResult.ResJsonString(true, "", "");
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    	finally{
    		if(res != null) res.close();
    	}
    }
    
    public String DeleteBarcode(String jsonField) {
    	try{
    		Gson gson = new Gson();
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		String barcode = jsonObj.get("Barcode").getAsString();
    		String parentId = jsonObj.get("ParentId").getAsString();
    		String typeName = jsonObj.get("TypeName").getAsString();
    		StringBuilder sqlWhere = new StringBuilder();
    		if(!barcode.equals("")) sqlWhere.append("and Barcode = '"+barcode+"' ");
    		sqlWhere.append("and ParentId = '"+parentId+"' and TypeName = '"+typeName+"' ");
    		
    		return ResResult.ResJsonString(dbHelper.Delete("Barcodes", sqlWhere.toString()), "", "");
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    }
    
    public String GetKeyValue(String jsonField) {
    	Cursor res = null;
    	try{
    		Gson gson = new Gson();
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		
    		String sKey = jsonObj.get("KeyName").getAsString();
    		String sType = jsonObj.get("TypeName").getAsString();
    		
    		String sqlWhere = "and KeyName = '"+sKey+"' and TypeName = '"+sType+"' ";
        	res = dbHelper.GetSingle("KeyValue", sqlWhere);
        	if(res != null && res.getCount() > 0){
        		if(res.moveToNext()){
        			return ResResult.ResJsonString(true, "", res.getString(2));	
        		}
        	}
        	return ResResult.ResJsonString(true, "", "");
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    	finally{
    		if(res != null) res.close();
    	}
    }
    
    public String InsertKeyValue(String jsonField){
    	try{
        	Gson gson = new GsonBuilder().disableHtmlEscaping().create();  
    		JsonObject jsonObj = gson.fromJson(jsonField, JsonObject.class);
    		String sKey = jsonObj.get("KeyName").getAsString();
    		String sType = jsonObj.get("TypeName").getAsString();
    		String sValue = jsonObj.get("ContentValue").getAsString();
    		
    		SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");       
    		Date currTime = new Date(System.currentTimeMillis());
    		String sLastUpdatedDate = formatter.format(currTime);
    		
    		Map<String, Object> items = new HashMap<String, Object>();
    		items.put("KeyName", sKey);
    		items.put("ContentValue", sValue);
    		items.put("TypeName", sType);
    		items.put("LastUpdatedDate", sLastUpdatedDate);
    		
    		String sqlWhere = "and KeyName = '"+sKey+"' and TypeName = '"+sType+"' ";
    		if(!dbHelper.IsExist("KeyValue", sqlWhere)){
    			dbHelper.Insert("KeyValue", items);
    		}
    		else{
    			dbHelper.Update("KeyValue", items);
    		}
    		
    		return ResResult.ResJsonString(true, "", "");
    	}
    	catch(Exception ex){
    		return ResResult.ResJsonString(false, ex.getMessage(), "");
    	}
    }
    
    public String GetSplitValue(String s,String k){
    	String[] arr = s.split("|");
    	for (int i = 0; i < arr.length; i++) {
            String key = "" + k + "=";
            if (arr[i].indexOf(key) > -1) {
                return arr[i].replace(key, "");
            }
        }
        return "";
    }
}
