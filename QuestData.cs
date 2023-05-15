using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData 
{
	public string questName;
	public int[] npcid;

	public QuestData(string name,int [] npc)
	{
		questName = name;
		npcid = npc;
	}
}
