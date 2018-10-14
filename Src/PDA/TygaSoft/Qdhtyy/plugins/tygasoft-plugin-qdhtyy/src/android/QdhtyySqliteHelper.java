package com.tygasoft.dbutility;

import java.util.Map;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.content.ContentValues;
import android.database.Cursor;
import android.database.DatabaseUtils;

public class QdhtyySqliteHelper extends SQLiteOpenHelper {

	static final String DbName = "QdhtyyDb";
	static final String[] DbTables = {"KeyValue","Barcodes" };
	
	public QdhtyySqliteHelper(Context context) {
		super(context, DbName, null, 1);
	}

	@Override
	public void onCreate(SQLiteDatabase db) {
		db.execSQL("CREATE TABLE IF NOT EXISTS KeyValue (Id integer primary key, KeyName nvarchar(100), ContentValue nvarchar(1000),TypeName varchar(100),LastUpdatedDate datetime)");
		db.execSQL("CREATE TABLE IF NOT EXISTS Barcodes (Id integer primary key, Barcode nvarchar(256),ParentId varchar(36), ContentValue nvarchar(1000),TypeName varchar(100),LastUpdatedDate datetime)");
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		for (int i = 0; i < DbTables.length; i++) {
			db.execSQL("DROP TABLE IF EXISTS " + DbTables[i] + "");
		}
		onCreate(db);
	}

	public Cursor ExecuteReader(String tableName,String sqlWhere) {
        SQLiteDatabase db = this.getReadableDatabase();
        String sql = "select * from "+tableName+" ";
        if(!sqlWhere.equals("")) sql += "where 1=1 "+sqlWhere+" ";
		sql += " order by LastUpdatedDate desc ";
        Cursor res =  db.rawQuery(sql, null);
        
        return res;
    }
	
	public Cursor GetSingle(String tableName,String sqlWhere) {
        SQLiteDatabase db = this.getReadableDatabase();
        String sql = "select * from "+tableName+" ";
        if(!sqlWhere.equals("")) sql += "where 1=1 "+sqlWhere+" ";
        sql += "limit 1 ";
        Cursor res =  db.rawQuery(sql, null);
        
        return res;
    }
	
	public Cursor GetById(String tableName,int Id) {
      SQLiteDatabase db = this.getReadableDatabase();
      Cursor res = db.rawQuery( "select * from "+tableName+" where Id="+Id+"", null );
      return res;
   }
	
	public int TotalRows(String tableName) {
		SQLiteDatabase db = this.getReadableDatabase();
		return (int)DatabaseUtils.queryNumEntries(db, tableName);
	}
	
	public boolean IsExist(String tableName,String sqlWhere) {
		SQLiteDatabase db = this.getReadableDatabase();
        String sql = "select * from "+tableName+" ";
        if(!sqlWhere.equals("")) sql += "where 1=1 "+sqlWhere+" ";
        sql += "limit 1 ";
        Cursor res =  db.rawQuery(sql, null);
        if(res != null && res.getCount() > 0) return true;
        return false;
	}
	
	public boolean Insert(String tableName, Map<String, Object> items) {
		SQLiteDatabase db = this.getWritableDatabase();
		ContentValues parms = new ContentValues();
		for(String key : items.keySet()){
			parms.put(key, (String)items.get(key));
		}
		return db.insert(tableName, null, parms) > 0;
	}

	public boolean Update(String tableName, Map<String, Object> items) {
		SQLiteDatabase db = this.getWritableDatabase();
		ContentValues parms = new ContentValues();
		for(String key : items.keySet()){
			parms.put(key, (String)items.get(key));
		}
		//return db.update(tableName, parms, "Barcode = ? and ParentId = ? ", new String[] { (String)parms.get("Barcode"),(String)parms.get("ParentId") }) > 0;
		return db.update(tableName, parms, "Id = ? ", new String[] { (String)parms.get("Id") }) > 0;
	}

	public boolean Delete(String tableName,Integer Id) {
		SQLiteDatabase db = this.getWritableDatabase();
		String sqlWhere = "";
		String[] parms = null;
		if(Id > 0){
			sqlWhere = "Id = ? ";
			parms = new String[] {Integer.toString(Id)};
		}
		return db.delete(tableName, sqlWhere, parms) > 0;
	}
	
	public boolean Delete(String tableName,String sqlWhere) {
		SQLiteDatabase db = this.getWritableDatabase();
		String sql = "delete from "+tableName+" ";
		if(!sqlWhere.equals("")) sql += "where 1=1 "+sqlWhere+" ";
		db.execSQL(sql);
		return true;
	}
}
