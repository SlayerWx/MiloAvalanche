package com.slayerwx.slayerwxlogger;
import android.app.Activity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
public class SLogger {
    public static final SLogger _instance = new SLogger();
    private static final String LogName = "DayLoggin.txt";
    private static Activity unityActivity = null;
    EditText myEditText;
    public static SLogger GetInstance(){
        return _instance;
    }
    public void CreateDayLogger(Activity a)
    {
        unityActivity =a;
        //myEditText = a.findViewById();
    }
}
