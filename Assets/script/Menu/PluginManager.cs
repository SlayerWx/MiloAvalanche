using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PluginManager : MonoBehaviour
{
    SlayerWxLogger SLogger = new SlayerWxLogger();
    public TMP_Text LogText;
    int i = 0;
    private void Start()
    {
        i = 0;
        SLogger.Init();
    }
    public void Write()
    {
        i++;
        SLogger.Wirte(i.ToString());
    }
    public void ReadLog()
    {
        string[] aux;
        aux = SLogger.Read();
        foreach (string n in aux)
        {
            LogText.text += n + "\n";
        }
    }
    public void Test()
    {
        LogText.text = " "+ SLogger.count + " ";
    }
}
