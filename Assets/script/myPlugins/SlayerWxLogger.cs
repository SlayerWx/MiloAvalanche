using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class SlayerWxLogger : MonoBehaviour
{
#if PLATFORM_ANDROID && !UNITY_EDITOR
    const string PACK_NAME = "com.slayerwx.slayerwxlogger";
    const string LOGGER_CLASS_NAME = "SLogger";
    AndroidJavaClass SLoggerClass = null;
    AndroidJavaObject SLoggerOBJ = null;
    AndroidJavaObject activity = null;
#endif
    public static SlayerWxLogger instance = null;
    public void Awake()
    {
        if(instance == null)
        instance = this;
    }
    
    private void InitPlugin()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        SLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        SLoggerOBJ = SLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
        AndroidJavaClass unityJClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activity = unityJClass.GetStatic<AndroidJavaObject>("currentActivity");
		
		
		if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
		{
			
			Permission.RequestUserPermission(Permission.ExternalStorageWrite);
		}
		
#endif
    }
    public void Init()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        if (SLoggerOBJ == null)
        {
            InitPlugin();
			if(Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            SLoggerOBJ.Call("CreateDayLogger", activity);
        }
#endif
    }
    public void Wirte(string data)
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        if (SLoggerOBJ != null)
        {
			if(Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            SLoggerOBJ.Call("WriteFile", data);
        }
#endif
    }
    public string[] Read()
    {
        string[] a = null;
#if PLATFORM_ANDROID && !UNITY_EDITOR
        if (SLoggerOBJ != null)
        {
			if(Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            a = SLoggerOBJ.Call<string[]>("ReadFile");
        }
#endif
        return a;
    }
    public void Delete()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        if (SLoggerOBJ != null)
        {
			if(Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            SLoggerOBJ.Call<string[]>("DeleteLog");
        }
#endif
    }
}
