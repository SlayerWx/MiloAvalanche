using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// conseguir main activity de unity para hacer la alerta a la hora de borrar el archivo
// cuidado donde esta corriendo el activity, en que entorno esta corriendo hara de que dependa como guardar el archivo
public class SlayerWxLogger
{
#if PLATFORM_ANDROID
    const string PACK_NAME = "com.slayerwx.slayerwxlogger";
    const string LOGGER_CLASS_NAME = "SLogger";
    public int count = 0;
    AndroidJavaClass SLoggerClass = null;
    AndroidJavaObject SLoggerOBJ = null;
    AndroidJavaObject activity = null;
    AndroidJavaObject jList = null;
    
    private void InitPlugin()
    {
        SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        SLoggerOBJ = SLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
        AndroidJavaClass unityJClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activity = unityJClass.GetStatic<AndroidJavaObject>("currentActivity");
        jList = new AndroidJavaClass("java.util.ArrayList");

    }
    public void Init()
    {
        if (SLoggerOBJ == null)
            InitPlugin();
        SLoggerOBJ.Call("CreateDayLogger",activity);
    }
    public void Wirte(string data)
    {
        if(SLoggerOBJ != null)
        SLoggerOBJ.Call("WriteFile", data);
    }
    public string[] Read()
    {
        string[] a = null;
        if (SLoggerOBJ != null)
        {
            a = SLoggerOBJ.Call<string[]>("ReadFile");
        }
        count = a.Length;
        return a;
    }
#endif
}
