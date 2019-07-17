package com.tygasoft.plugins;

import org.apache.cordova.CallbackContext;
import org.apache.cordova.CordovaPlugin;
import org.json.JSONArray;
import org.json.JSONException;

import android.app.Activity;
import android.app.PendingIntent;
import android.content.Intent;
import android.content.IntentFilter;
import android.nfc.NdefMessage;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.tech.MifareClassic;
import android.nfc.tech.Ndef;
import android.nfc.tech.NfcA;
import android.nfc.tech.NfcB;
import android.nfc.tech.NfcF;
import android.nfc.tech.NfcV;
import android.util.Log;

public class NfcPlugin extends CordovaPlugin {
	
	private static final String TAG = "NfcPlugin--";
	private PendingIntent pendingIntent = null;
	private NdefMessage p2pMessage = null;
	
	@Override
    public boolean execute(String action, JSONArray args, final CallbackContext callbackContext) throws JSONException {
		if (action.equals("GetHelloWord")) {
            String message = args.getString(0);
            callbackContext.success(message);
            return true;
        }
		else if (action.equals("StartNfc")) {
			startNfc();
            callbackContext.success(1);
            return true;
        }
		else if (action.equals("StopNfc")) {
			stopNfc();
            callbackContext.success(1);
            return true;
        }
		else if (action.equals("GetResult")) {
            callbackContext.success(getNfcResult());
            return true;
        }
		
		return false;
	}

	@Override
    public void onNewIntent(Intent intent) {
	    super.onNewIntent(intent);
	    setMyIntent(intent);  
    }
	
	private String getNfcResult(){
		Tag tagFromIntent = getMyIntent().getParcelableExtra(NfcAdapter.EXTRA_TAG);
		String nfcCode = getTagId(tagFromIntent);
		if(!nfcCode.equals("")) setMyIntent(new Intent());
		return nfcCode;
	}
	
	private void startNfc() {
        createPendingIntent(); // onResume can call startNfc before execute
        NfcAdapter nfcAdapter = NfcAdapter.getDefaultAdapter(getMyActivity());
        if (nfcAdapter != null && !getMyActivity().isFinishing()) {
            try {
                nfcAdapter.enableForegroundDispatch(getMyActivity(), getPendingIntent(), getIntentFilters(), getTechLists());

                if (p2pMessage != null) {
                    nfcAdapter.setNdefPushMessage(p2pMessage, getMyActivity());
                }
            } catch (IllegalStateException e) {
                // issue 110 - user exits app with home button while nfc is initializing
                Log.w(TAG, "Illegal State Exception starting NFC. Assuming application is terminating.");
            }
        }
    }

    private void stopNfc() {
        Log.d(TAG, "stopNfc");
        NfcAdapter nfcAdapter = NfcAdapter.getDefaultAdapter(getMyActivity());
        if (nfcAdapter != null) {
            try {
                nfcAdapter.disableForegroundDispatch(getMyActivity());
            } catch (IllegalStateException e) {
                // issue 125 - user exits app with back button while nfc
                Log.w(TAG, "Illegal State Exception stopping NFC. Assuming application is terminating.");
            }
        }
    }
    
    private void createPendingIntent() {
        if (pendingIntent == null) {
            Activity activity = getMyActivity();
            Intent intent = new Intent(activity, activity.getClass());
            intent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP | Intent.FLAG_ACTIVITY_CLEAR_TOP);
            pendingIntent = PendingIntent.getActivity(activity, 0, intent, 0);
        }
    }
	
	private PendingIntent getPendingIntent() {
        return pendingIntent;
    }
	
	private IntentFilter[] getIntentFilters() {
		IntentFilter ifilters = new IntentFilter();
        ifilters.addAction(NfcAdapter.ACTION_NDEF_DISCOVERED);
        ifilters.addAction(NfcAdapter.ACTION_TAG_DISCOVERED);
        ifilters.addAction(NfcAdapter.ACTION_TECH_DISCOVERED);
		//intent 过滤器，过滤类型为 NDEF_DISCOVERED，TAG_DISCOVERED，TECH_DISCOVERED
        IntentFilter[] mFilters = new IntentFilter[] {ifilters,}; 

        return mFilters;
    }
	
	private String[][] getTechLists(){
		//存放支持technologies的数组
		String[][] mTechLists = new String[][] {
            new String[] {
                Ndef.class.getName(),
                NfcA.class.getName(),
                NfcB.class.getName(),
                NfcF.class.getName(),
                NfcV.class.getName(),
                MifareClassic.class.getName()
            }
        };
		
		return mTechLists;
	}
    
    private Activity getMyActivity() {
    	return this.cordova.getActivity();
    }

    private Intent getMyIntent() {
        return getMyActivity().getIntent();
    }

    private void setMyIntent(Intent intent) {
    	getMyActivity().setIntent(intent);
    }
	
	private String getTagId(Tag tagFromIntent){
		if(tagFromIntent == null) return "";
        //读取id
        String id = bytesToHexString(tagFromIntent.getId());
        return id;
    }
	
	private String bytesToHexString(byte[] src) {
        StringBuilder stringBuilder = new StringBuilder("0x");
        if (src == null || src.length <= 0) {
            return null;
        }
        char[] buffer = new char[2];
        for (int i = 0; i < src.length; i++) {
            buffer[0] = Character.forDigit((src[i] >>> 4) & 0x0F, 16);
            buffer[1] = Character.forDigit(src[i] & 0x0F, 16);
            stringBuilder.append(buffer);
        }
        return stringBuilder.toString();
    }
}