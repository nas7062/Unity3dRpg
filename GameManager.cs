using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController effectskill;
    public Talk talkManager;
    public QuestManager questManager;
    public GameObject image;
    public Text talktext;
    public GameObject obj;
    public PoolManager pool;
    public bool isAction;
    public int talkIdx;

	// Update is called once per frame

	private void Awake()
	{
        instance = null;
	}
	public void Action(GameObject sobj)
    {
     
         obj = sobj;
         ObjData objdata = obj.GetComponent<ObjData>();
         Talk(objdata.id);


        image.SetActive(isAction);
    }
       
   

    void Talk(int id)
	{

        int questTalkIndex = questManager.GetQuestTalkIndex(id);
       string talkdata = talkManager.GetTalking(id+questTalkIndex,talkIdx);


        if (talkdata == null)
		{
            isAction = false;
            talkIdx = 0;
            questManager.CheckQuest(id);
            return;
        }
            

      
        talktext.text = talkdata;


        isAction = true;
        
        if(Input.GetButtonDown("Jump") &&obj !=null)
            talkIdx++;
        

		

    }
}
