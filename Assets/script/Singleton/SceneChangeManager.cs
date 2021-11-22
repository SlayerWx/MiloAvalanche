using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
    public static string nextScene = "Menu";
    public static string fromScene = "Game";

    public static void SceneChange(string next)
    {
        nextScene = next;
        SceneManager.LoadScene("Load", LoadSceneMode.Additive);
    }
}