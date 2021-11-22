using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
    public static string nextScene = "Menu";
    public static string fromScene = "";
    public static bool waitToButtonStart = true;
    private void Start()
    {
        fromScene = SceneManager.GetActiveScene().name;
    }
    public static void SceneChange(string next,bool waitForButton)
    {
        waitToButtonStart = waitForButton;
        nextScene = next;
        SceneManager.LoadScene("Load", LoadSceneMode.Additive);
    }
}