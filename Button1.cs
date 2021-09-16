using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour
{
    public void theStartGameButtonIsOnClick()
    {
        UnityEngine.Debug.Log("开始游戏");
        SceneManager.LoadScene("Loading");
    }
    public void theHomeButtonIsOnClick()
    {
        SceneManager.LoadScene("StartPage");
    }
}
