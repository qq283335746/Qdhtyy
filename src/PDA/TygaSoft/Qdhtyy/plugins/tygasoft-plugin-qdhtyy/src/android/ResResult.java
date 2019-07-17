package com.tygasoft.utility;

import com.google.gson.Gson;
import com.tygasoft.model.ResResultInfo;

public class ResResult {
	public static String ResJsonString(boolean isOk, String msg, Object data)
    {
		Gson gson = new Gson();
        return gson.toJson(new ResResultInfo(isOk ? 1000 : 1001, msg, data));
    }
}
