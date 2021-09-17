using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
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
    public bool isColorful;

    //On Click()
    public void balabala()
    { 
         try
        {
            if (isColorful)
            {
                stopColorful();
                return;
            }
            if (isEffect == true)
                {
                    counter -= 1;
                    StopAllCoroutines();
                    isEffect = false;
                    textUpload(textUpdate());
                    counter += 1;
                    return;
                }
                else
                {
                    StartCoroutine(textEffect(textUpdate()));
                }
            counter += 1;
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }
        
    }

    private void stopColorful()
    {
        counter -= 1;
        StopAllCoroutines();
        isColorful = false;
        isEffect = false;

        //which chapter
        String temp = chapter0[counter];
        String[] tempList = temp.Split('?');
        String color = tempList[2];

        int length = tempList.Length;
        //length = 4;
        temp = "";
        for (int a = 3; a<length; a=a+1){
            temp += tempList[a];
        }
        tempList = temp.Split('@');
        //仅仅有两个@的句子
        if(tempList.Length == 3)
        {
            temp = tempList[0] + "<color=" + color + ">" + tempList[1] + "</color>" + tempList[2];
        }
        //其他暂时不考虑，请自行设计
        UnityEngine.Debug.Log(temp);
        text.GetComponent<Text>().text= temp;
        counter += 1;
        return;
    }
    private string textUpdate()
    {
        String content = "";
        if(whichChapter == 0)
        {
            content = chapter0[counter];
        }
        else if(whichChapter == 1)
        {
            //content = chapter1[counter];
        }
        else if (whichChapter == 2)
        {
            //content = chapter2[counter];
        }
        else if (whichChapter == 3)
        {
            //content = chapter3[counter];
        }
        else
        {
            UnityEngine.Debug.Log("章节不存在");
        }
        content = content.Replace("？", "?");
        if (content.StartsWith("?"))
        {
            do
            {
                content = textFix(content);
            } while (content.StartsWith("?"));
        }

        return content;
    }

    private string textFix(string content)
    {
        if (content.StartsWith("?注释?"))
        {
            counter += 1;
        }
        if (content.StartsWith("?color?"))
        {
            //粉色
            if (content.StartsWith("?color?red?"))
            {
                if (isColorful)
                {
                    return "";
                }
                content = content.Replace("?color?red?", "");
                String[] temp = content.Split('@');
                isColorful = true;
                StartCoroutine(textColorfulEffect(temp,"red"));
            }

 
        }
        return textUpdate();
    }

    private void textUpload(string content)
    {
        if (isColorful)
        {
            isColorful = false;
            return;
        }
        text.GetComponent<Text>().text = content;
    }

    private IEnumerator textColorfulEffect(String[] balabala,String color)
    {
        isEffect = true;
        text.GetComponent<Text>().text = "";
        //需要变色之前的文本
        foreach (var i in balabala[0].ToCharArray())
        {
            text.GetComponent<Text>().text += i;
            yield return new WaitForSeconds(textSpeed);
        }
        //需要变色的文本
        foreach (var i in balabala[1].ToCharArray())
        {
            text.GetComponent<Text>().text += "<color="+color+">";
            text.GetComponent<Text>().text += i;
            text.GetComponent<Text>().text += "</color>";
            yield return new WaitForSeconds(textSpeed);
        }
        //剩下的文本。如果你想做两段变色请自行设计
        foreach (var i in balabala[2].ToCharArray())
        {
            text.GetComponent<Text>().text += i;
            yield return new WaitForSeconds(textSpeed);
        }
        isEffect = false;
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
