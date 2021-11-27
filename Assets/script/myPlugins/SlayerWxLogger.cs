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
    AndroidJavaClass SLoggerClass = null;
    AndroidJavaObject SLoggerOBJ = null;
    AndroidJavaObject activity = null;
    void Init()
    {
        SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        SLoggerOBJ = SLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
        AndroidJavaClass unityJClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activity = unityJClass.GetStatic<AndroidJavaObject>("currentActivity");

    }
    //public void SendLog(string smg)
    //{
    //    if (SLoggerOBJ == null)
    //        Init();
    //    SLoggerOBJ.Call("SendLog",smg);
    //}
#endif
}
