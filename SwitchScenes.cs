using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Start()方法被触发了");
        SceneManager.LoadSceneAsync("MainGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
