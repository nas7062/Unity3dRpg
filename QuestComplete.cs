using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplete 
{
	public QuestType questType;

	public int Requiredkill;
	public int Currentkill;

	public void EnermyKilled()
	{
		if (questType == QuestType.KILL)
			Currentkill++;

	}
}

public enum QuestType
{ 
	KILL, BUY
}

