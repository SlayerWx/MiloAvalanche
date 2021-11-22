using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallNextScene : MonoBehaviour
{
    public string nextScene;
    public void NextScene()
    {
        SceneChangeManager.SceneChange(nextScene);
    }
}
