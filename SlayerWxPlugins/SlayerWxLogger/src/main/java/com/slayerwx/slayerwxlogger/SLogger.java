package com.slayerwx.slayerwxlogger;
import android.app.Activity;

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
    private File LogFile = null;
    EditText myEditText;
    public void CreateDayLogger(Activity a)
    {
        Log.d("SLogger-CreateDayLogger", "Create Init");
        try {
            unityActivity = a;
            Log.d("SLogger-CreateDayLogger", "TrySuccess");
            CreateFile();

        }catch (NullPointerException e){
            Log.d("SLogger-CreateDayLogger", "null pointer exception, GetApplicationContext from Unity Activity");
            //e.printStackTrace();
        }
    }
    public void CreateFile()
    {
        Log.d("SLogger-CreateFile", "CreateFile");
        try {
            //if (LogFile==null)
               // LogFile = new File(unityActivity.getApplicationContext().getFilesDir(), LogName);
            //File
            Log.d("SLogger-CreateFile", "TrySuccess");
        }catch (NullPointerException e)
        {
            Log.d("SLogger-CreateFile", "null pointer exception, failed to Create File");

        }
    }

    public void WriteFile(String data) {
        try {
          //  if(LogFile.exists()) {
                OutputStreamWriter outputStreamWriter = new OutputStreamWriter(unityActivity.getApplicationContext().openFileOutput(LogName, unityActivity.getApplicationContext().MODE_APPEND));
                outputStreamWriter.write(data);
                outputStreamWriter.close();
            Log.e("SLogger-WriteFile", "Write Success ");
            //}
        }
        catch (IOException e) {
            Log.e("SLogger-WriteFile", "File write failed: " + e.toString());
        }
    }
    public String[] ReadFile() {
        List<String> linesList = new ArrayList<String>();
        try {
           // if(LogFile.exists()) {
                FileInputStream fileIn = unityActivity.openFileInput(LogName);
                InputStreamReader inputRead = new InputStreamReader(fileIn);
                BufferedReader br = new BufferedReader(inputRead);
                String line = br.readLine();
                while(line !=null)
                {
                    linesList.add(line);

                    Log.e("SLogger-WriteFile", "Read: " + line.toString());
                    line = br.readLine();
                }
                inputRead.close();

            Log.e("SLogger-WriteFile", "Read success ");
            //}

        }
        catch (IOException e) {
            Log.e("SLogger-WriteFile", "File Read failed: " + e.toString());
        }
        String[] aux = new String[linesList.size()];
        aux = linesList.toArray(aux);
        return aux;
    }
}
