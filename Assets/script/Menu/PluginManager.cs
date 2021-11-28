using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PluginManager : MonoBehaviour
{
    public TMP_Text LogText;
    public ScrollEnlarge scrollEnlarge;
    
    private void Start()
    {
        SlayerWxLogger.instance.Init();
    }
    public void WirteLog()
    {
        SlayerWxLogger.instance.Wirte(System.DateTime.Now.Month + " M/" + System.DateTime.Now.Day + " D/" 
            + System.DateTime.Now.Year + " Y/" + System.DateTime.Now.Hour + ":"+ System.DateTime.Now.Minute + 
            " T/- " +  (int)CharacterInfo.myref.points + " Points");
    }
    public void ReadLog()
    {
        LogText.text = "";
        string[] aux;
        aux = SlayerWxLogger.instance.Read();
        if (aux != null)
        {
            foreach (string n in aux)
            {
                LogText.text += n + "\n";
            }
            scrollEnlarge.ChangeHeight();
        }
    }
    public void DeleteLog()
    {
        LogText.text = "";
        SlayerWxLogger.instance.Delete();
    }
}
