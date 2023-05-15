using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    IDictionary<int, string[]> talk;
    QuestGive quest;

    void Awake()
    {
        talk = new Dictionary<int, string[]>();
        quest = FindObjectOfType<QuestGive>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        

        //quest
        talk.Add(10 + 1, new string[] { "상점에서 물건을 구해다 줄 수 잇겠나.", "그리고 나에게 다시와줘 " });
        talk.Add(11 + 1, new string[] { "고마워 ", "옆에있는 전사에게 가봐" });
       
        talk.Add(20 + 3, new string[] { "안녕 ", "이제 다른 도시로 떠나볼까 ","가서 보스를 처치해줘" });
        talk.Add(21 + 6, new string[] { "이쪽은 ", "길이 아닌 것 같아 ","다른 곳으로 가보자" });
    }

    public string GetTalking(int id,int talkIdx)
	{
        if(!talk.ContainsKey(id))
		{
            if (talkIdx == talk[id - id % 10].Length)
            {
                return null;
            }
            else
                return talk[id - id % 10][talkIdx];
		}


        if (talkIdx == talk[id].Length)
		{
            quest.GetComponent<QuestGive>().miniquest.SetActive(false);
            return null;
        }
            
        else
            return talk[id][talkIdx];
	}
}
