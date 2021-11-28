package com.slayerwx.slayerwxlogger;
import android.app.Activity;

import android.net.Uri;
import android.os.Bundle;
import android.os.Message;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;
import android.content.Context;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.File;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import android.util.Log;
public class SLogger {
    public static final SLogger _instance = new SLogger();
    private static final String LogName = "DayLoggin.txt";
    public static SLogger GetInstance(){
        return _instance;
    }
    private Activity unityActivity = null;
    public void CreateDayLogger(Activity a)
    {
        Log.d("SLogger-CreateDayLogger", "Create Init");
        try {
            unityActivity = a;
            Log.d("SLogger-CreateDayLogger", "TrySuccess");

        }catch (NullPointerException e){
            Log.d("SLogger-CreateDayLogger", "null pointer exception, GetApplicationContext from Unity Activity");
            //e.printStackTrace();
        }
    }

    public void WriteFile(String data) {
        try {
          //  if(LogFile.exists()) {
                OutputStreamWriter outputStreamWriter = new OutputStreamWriter(unityActivity.getApplicationContext().openFileOutput(LogName, unityActivity.getApplicationContext().MODE_APPEND));
                outputStreamWriter.write(data + "\n");
                outputStreamWriter.close();
            Log.d("SLogger-WriteFile", "Write Success, data: " + data);
            //}
        }
        catch (IOException e) {
            Log.d("SLogger-WriteFile", "File write failed: " + e.toString());
        }
    }
    public String[] ReadFile() {
        List<String> linesList = new ArrayList<String>();
        try {

                FileInputStream fileIn = null;
                fileIn = unityActivity.openFileInput(LogName);
             if(fileIn != null) {
                 InputStreamReader inputRead = new InputStreamReader(fileIn);
                 BufferedReader br = new BufferedReader(inputRead);
                 String line = br.readLine();
                 while (line != null) {
                     linesList.add(line);

                     Log.d("SLogger-WriteFile", "Read: " + line.toString());
                     line = br.readLine();
                 }
                 inputRead.close();
             }
            Log.d("SLogger-WriteFile", "Read success ");
            //}

        }
        catch (IOException e) {
            Log.d("SLogger-WriteFile", "File Read failed: " + e.toString());
        }
        String[] aux = new String[linesList.size()];
        aux = linesList.toArray(aux);
        return aux;
    }
    public void Debug(String data)
    {
        Log.d("LOG =>",data);
    }
    public void DeleteLog()
    {
        //File a = new File(unityActivity.getApplicationContext().getFilesDir(), LogName);
        //Log.d("SLogger-DeleteLog", "test name" + a.getName());
        //if(a.exists()) {
        //    a.delete();
        //}
        //Log.d("SLogger-DeleteLog", "Delete " + LogName + " in " + unityActivity.getApplicationContext().getFilesDir());
            Log.d("SLogger-DeleteLog","Trying Delete: " + unityActivity.getApplicationContext().getFilesDir() + LogName);
            unityActivity.getContentResolver().delete(Uri.parse(unityActivity.getApplicationContext().getFilesDir() + LogName),null,null);
            Log.d("SLogger-DeleteLog","Delete End");

    }
}
