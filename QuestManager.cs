using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questid;
    public int questidx;

	public GameObject[] QuestObjects;
    Dictionary<int, QuestData> questList;

	void Awake()
	{
        questList = new Dictionary<int, QuestData>();
        GenerateDate();
	}


	void GenerateDate()
	{
		questList.Add(10, new QuestData("상점에서 물건 구매하기 ", new int[] { 1, 1 }));

		questList.Add(20, new QuestData("보스 잡기", new int[] { 3, 3 }));
	}


	public int GetQuestTalkIndex(int id)
	{
        return questid + questidx;
	}

    public string CheckQuest(int id)
	{
		

        if(id == questList[questid].npcid[questidx])
            questidx++;

		ControlObject();
		if (questidx == questList[questid].npcid.Length)
			NextQuest();

		return questList[questid].questName;
	}
	public string CheckQuest()
	{

		return questList[questid].questName;
	}

	void NextQuest()
	{
		questid += 10;
		questidx = 0;
	}

	void ControlObject()
	{
		switch (questid)
		{
			case 10:
				if (questidx == 1)
					QuestObjects[0].SetActive(true);
					break;
			case 20:
				if (questidx == 1)
					QuestObjects[0].SetActive(false);
				break;

		}

	}
}
