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
        talk.Add(10 + 1, new string[] { "�������� ������ ���ش� �� �� �հڳ�.", "�׸��� ������ �ٽÿ��� " });
        talk.Add(11 + 1, new string[] { "���� ", "�����ִ� ���翡�� ����" });
       
        talk.Add(20 + 3, new string[] { "�ȳ� ", "���� �ٸ� ���÷� �������� ","���� ������ óġ����" });
        talk.Add(21 + 6, new string[] { "������ ", "���� �ƴ� �� ���� ","�ٸ� ������ ������" });
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
