package com.tygasoft.plugins;

import java.util.LinkedList;
import java.util.Queue;

import org.apache.cordova.CallbackContext;
import org.apache.cordova.CordovaPlugin;
import org.json.JSONArray;
import org.json.JSONException;

import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;

public class BarcodeScanPlugin  extends CordovaPlugin{
	
	private Queue<String> queue;
	
	@Override
    public boolean execute(String action, JSONArray args, final CallbackContext callbackContext) throws JSONException {
		if (action.equals("GetHelloWord")) {
            String message = args.getString(0);
            callbackContext.success(message);
            return true;
        }
		else if (action.equals("Init")) {
			Init();
			callbackContext.success(1);
			return true;
		}
		else if (action.equals("GetResult")) {
			callbackContext.success(GetResult());
			return true;
		}
		else if (action.equals("Close")) {
			Close();
			callbackContext.success(1);
			return true;
		}
		
		return false;
	}
	
	private BroadcastReceiver mScanReceiver = new BroadcastReceiver(){
        @Override
        public void onReceive(Context context, Intent intent){
        	//setMyIntent(intent);
        	String barcode = intent.getStringExtra("Scan_context");
        	if(!queue.contains(barcode)) queue.offer(barcode);
        }
    };
    
    private void Init(){
    	IntentFilter scanIntentFilter = new IntentFilter();
    	scanIntentFilter.addAction("com.android.scancontext");
    	scanIntentFilter.addAction("com.android.scanservice.scancontext");
    	getMyActivity().registerReceiver(mScanReceiver, scanIntentFilter);
    	if(queue == null) queue = new LinkedList<String>();
    }
    
    private void Close(){
    	getMyActivity().unregisterReceiver(mScanReceiver);
    	if(queue != null) queue = null;
    }
    
    private String GetResult(){
    	if(queue == null || queue.isEmpty()) return "";
    	return queue.poll();
    	//return getMyIntent().getStringExtra("Scan_context");
    }
    
    private Activity getMyActivity() {
    	return this.cordova.getActivity();
    }

//    private Intent getMyIntent() {
//        return getMyActivity().getIntent();
//    }
//
//    private void setMyIntent(Intent intent) {
//    	getMyActivity().setIntent(intent);
//    }
}
