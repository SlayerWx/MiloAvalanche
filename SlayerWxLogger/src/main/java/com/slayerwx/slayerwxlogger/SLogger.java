package com.slayerwx.slayerwxlogger;

import android.app.Activity;
import android.os.Environment;
import android.util.Log;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class SLogger {

    public static final SLogger _instance = new SLogger();
    private static final String LOG_NAME = "DayLogging.txt";
    private Activity unityActivity = null;

    public static SLogger GetInstance() {
        return _instance;
    }

    public void CreateDayLogger(Activity a) {
        Log.d("SLogger-CreateDayLogger", "Create Init");
        unityActivity = a;
    }

    public void WriteFile(String data) {
        try {
            File myAppDir = unityActivity.getExternalFilesDir(null);
            if (myAppDir != null) {
                File logFile = new File(myAppDir, LOG_NAME);
                FileOutputStream outputStream = new FileOutputStream(logFile, true);
                outputStream.write((data + "\n").getBytes());
                outputStream.close();
                Log.d("SLogger-WriteFile", "Write Success, data: " + data);
            }
        } catch (IOException e) {
            Log.d("SLogger-WriteFile", "File write failed: " + e.toString());
        }
    }

    public String[] ReadFile() {
        List<String> linesList = new ArrayList<>();
        try {
            File myAppDir = unityActivity.getExternalFilesDir(null);
            if (myAppDir != null) {
                File logFile = new File(myAppDir, LOG_NAME);
                FileInputStream fileInputStream = new FileInputStream(logFile);
                InputStreamReader inputRead = new InputStreamReader(fileInputStream);
                BufferedReader br = new BufferedReader(inputRead);
                String line = br.readLine();
                while (line != null) {
                    linesList.add(line);
                    Log.d("SLogger-ReadFile", "Read: " + line);
                    line = br.readLine();
                }
                inputRead.close();
            }
        } catch (IOException e) {
            Log.d("SLogger-ReadFile", "File Read failed: " + e.toString());
        }
        return linesList.toArray(new String[0]);
    }

    public void Debug(String data) {
        Log.d("LOG =>", data);
    }

    public void DeleteLog() {
        try {
            File myAppDir = unityActivity.getExternalFilesDir(null);
            if (myAppDir != null) {
                File logFile = new File(myAppDir, LOG_NAME);
                if (logFile.exists()) {
                    if (logFile.delete()) {
                        Log.d("SLogger-DeleteLog", "Delete Success");
                    } else {
                        Log.d("SLogger-DeleteLog", "Delete Failed");
                    }
                }
            }
        } catch (Exception e) {
            Log.d("SLogger-DeleteLog", "Delete Exception: " + e.toString());
        }
    }
}