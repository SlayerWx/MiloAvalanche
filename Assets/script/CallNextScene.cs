using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CallNextScene : MonoBehaviour
{
    public string nextScene;
    public bool waitForButtonStart = true;
    public void NextScene()
    {
        SceneChangeManager.SceneChange(nextScene, waitForButtonStart);
    }
}
