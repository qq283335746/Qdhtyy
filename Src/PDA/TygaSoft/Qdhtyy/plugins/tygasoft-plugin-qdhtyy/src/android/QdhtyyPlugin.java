package com.tygasoft.plugins;

import org.apache.cordova.CallbackContext;
import org.apache.cordova.CordovaPlugin;
import org.json.JSONArray;
import org.json.JSONException;

import com.tygasoft.bll.Qdhtyy;
import com.tygasoft.dbutility.QdhtyySqliteHelper;
import com.tygasoft.services.QdhtyyService;

public class QdhtyyPlugin extends CordovaPlugin {
	
	static QdhtyySqliteHelper dbHelper;
	
	@Override
    public boolean execute(String action, JSONArray args, final CallbackContext callbackContext) throws JSONException {
		if(dbHelper == null) dbHelper = new QdhtyySqliteHelper(this.cordova.getActivity());
		if (action.equals("GetHelloWord")) {
            callbackContext.success(args.getString(0));
            return true;
        }
		else if (action.equals("ValidateUser")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.ValidateUser(jsonField));
            return true;
        }
		else if (action.equals("GetAuthInfo")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.GetAuthInfo(jsonField));
            return true;
        }
		else if (action.equals("GetTaskList")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.GetTaskList(jsonField));
            return true;
        }
		else if (action.equals("GetBoxList")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.GetBoxList(jsonField));
            return true;
        }
		else if (action.equals("GetFeeQ")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.GetFeeQ(jsonField));
            return true;
        }
		else if (action.equals("GetInQTask")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.GetInQTask(jsonField));
            return true;
        }
		else if (action.equals("GetEtask")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.GetEtask(jsonField));
            return true;
        }
		else if (action.equals("GetEmpTlist")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.GetEmpTlist(jsonField));
            return true;
        }
		else if (action.equals("SaveTaskInfo")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.SaveTaskInfo(jsonField));
            return true;
        }
		else if (action.equals("SaveBoxInfo")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.SaveBoxInfo(jsonField));
            return true;
        }
		else if (action.equals("InsertBarcode")) {
			String jsonField = args.getString(0);
			Qdhtyy bll = new Qdhtyy(dbHelper);
			callbackContext.success(bll.InsertBarcode(jsonField));
            return true;
        }
		else if (action.equals("SaveBatchTaskCargo")) {
			String jsonField = args.getString(0);
			Qdhtyy bll = new Qdhtyy(dbHelper);
			callbackContext.success(bll.SaveBatchTaskCargo(jsonField));
            return true;
        }
		else if (action.equals("SaveTaskCargoInfo")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.SaveTaskCargoInfo(jsonField));
            return true;
        }
		else if (action.equals("SaveApplyTaskInfo")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.SaveApplyTaskInfo(jsonField));
            return true;
        }
		else if (action.equals("SaveETask")) {
			String jsonField = args.getString(0);
			QdhtyyService client = new QdhtyyService();
			callbackContext.success(client.SaveETask(jsonField));
            return true;
        }
		else if (action.equals("GetBarcodeList")) {
			String jsonField = args.getString(0);
			Qdhtyy bll = new Qdhtyy(dbHelper);
			callbackContext.success(bll.GetBarcodeList(jsonField));
            return true;
        }
		else if (action.equals("GetBarcodeInfo")) {
			String jsonField = args.getString(0);
			Qdhtyy bll = new Qdhtyy(dbHelper);
			callbackContext.success(bll.GetBarcodeInfo(jsonField));
            return true;
        }
		else if (action.equals("DeleteBarcode")) {
			String jsonField = args.getString(0);
			Qdhtyy bll = new Qdhtyy(dbHelper);
			callbackContext.success(bll.DeleteBarcode(jsonField));
            return true;
        }
		else if (action.equals("GetKeyValue")) {
			String jsonField = args.getString(0);
			Qdhtyy bll = new Qdhtyy(dbHelper);
			callbackContext.success(bll.GetKeyValue(jsonField));
            return true;
        }
		else if (action.equals("InsertKeyValue")) {
			String jsonField = args.getString(0);
			Qdhtyy bll = new Qdhtyy(dbHelper);
			callbackContext.success(bll.InsertKeyValue(jsonField));
            return true;
        }
        
        return false;
    }
}
