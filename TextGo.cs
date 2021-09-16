using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGo : MonoBehaviour
{
    public GameObject text;
    public static int whichChapter = 0;
    public string[] chapter0;
    public static int counter = 0;
    public static float textSpeed = 0.01f;
    public bool isEffect;

    public void balabala()
    {
        try
        {
            if(whichChapter == 0)
            {
                if(isEffect == true)
                {
                    counter -= 1;
                    StopAllCoroutines();
                    isEffect = false;
                    text.GetComponent<Text>().text = chapter0[counter];
                    counter += 1;
                    return;
                }
                else
                {
                    StartCoroutine(textEffect(chapter0[counter]));
                }
            }
            else
            {
                UnityEngine.Debug.Log("Error code 001");
                return;
            }
            counter += 1;
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }
        
    }

    public IEnumerator textEffect(String balabala)
    {
        isEffect = true;
        text.GetComponent<Text>().text = "";
                foreach (var i in balabala.ToCharArray())
                 {
                      text.GetComponent<Text>().text += i;
                      yield return new WaitForSeconds(textSpeed);
        }
        isEffect = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Context");
        TextAsset a  = Resources.Load("chapter0") as TextAsset;
        chapter0 = a.text.Split('\n');

        balabala();
    }
}
