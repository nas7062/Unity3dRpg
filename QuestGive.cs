using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestGive : MonoBehaviour
{
    public Quest quest;

    public PlayerController player;

    public GameObject questwindow;
    public GameObject image;
    public Text title;
    public Text descript;
    public GameObject miniquest;
    public Text minititle;
    public Text minicurrent;
    public Text result;
    public int minidescript;
    public int max;
    public void OpenQuest()
	{
        questwindow.SetActive(true);
        title.text = quest.title;
        descript.text = quest.description;
        
	}
    public void close()
	{
        image.SetActive(false);
	}

    public void AcceptQuest()
	{
        questwindow.SetActive(false);
        quest.isActive = true;
        miniquest.SetActive(true);
        quest.miniisActive = true;
        minititle.text = quest.minititle;
        minicurrent.text = minidescript.ToString();
        image.SetActive(false);
    }
  
  
}
