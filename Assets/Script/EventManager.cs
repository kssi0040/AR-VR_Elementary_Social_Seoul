﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EventManager : MonoBehaviour
{
    public Image PopUp;
    public RectTransform button;
    public AudioSource bookSound;
    public bool ishit = false;
	// Use this for initialization
	void Start ()
    {
        button.transform.gameObject.SetActive(false);
	}
	
    public void OnPointerDown()
    {
        Sprite HitTaiko = Resources.Load<Sprite>("Drum_Take_02");
        PopUp.sprite = HitTaiko;
        button.transform.gameObject.SetActive(true);
        ishit = true;
        AppManage.Instance.isComplite = false;
        bookSound.time = 0.0f;
        bookSound.Play();
    }

    public void OnPointerUp()
    {
        Sprite HitTaiko = Resources.Load<Sprite>("Drum_Take_01");
        PopUp.sprite = HitTaiko;
    }

    public void Next()
    {
        TextManager manager = GameObject.Find("TextManager").GetComponent<TextManager>();
        RectTransform Hit = GameObject.Find("Hit").GetComponent<RectTransform>();
        Hit.transform.gameObject.SetActive(false);
        button.transform.gameObject.SetActive(false);
        Image BG =GameObject.Find("BackGround").GetComponent<Image>();
        BG.overrideSprite = Resources.Load<Sprite>("Demo_BG");
        manager.count++;
        ishit = false;
        Text str = GameObject.Find("str").GetComponent<Text>();
        string text = Text_XML_Reader.Instance.scenario[manager.currentStage].text[Text_XML_Reader.Instance.scenario[manager.currentStage].Num[manager.count]];
        if (text.Contains("###"))
        {
            string temp = text.Replace("###", AppManage.Instance.Name);
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
        }
        else
        {
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
        }    
    }

    public void Next2()
    {
        TextManager manager = GameObject.Find("TextManager").GetComponent<TextManager>();
        button.transform.gameObject.SetActive(false);
        manager.TextBox.transform.gameObject.SetActive(true);
        manager.CharacterScroll.transform.gameObject.SetActive(true);
        Text str = GameObject.Find("str").GetComponent<Text>();
        string text = Text_XML_Reader.Instance.scenario[manager.currentStage].text[Text_XML_Reader.Instance.scenario[manager.currentStage].Num[manager.count]];
        if (text.Contains("###"))
        {
            string temp = text.Replace("###", AppManage.Instance.Name);
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
        }
        else
        {
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
        }
        ishit = true;
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
