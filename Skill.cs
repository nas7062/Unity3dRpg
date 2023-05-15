using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SkillTrees;

public class Skill : MonoBehaviour
{
	public int id;
	
	public int[] connectedUpgrades;
	
	
	public void UIUpdate()
	{

		GetComponent<Image>().color = skillTrees.skillLevels[id] >= skillTrees.skillCaps[id]
			? Color.yellow : skillTrees.skillPoint >=1 ? Color.green : Color.white;

		foreach(var connetedskill in connectedUpgrades)
		{
			skillTrees.skillList[connetedskill].gameObject.SetActive(skillTrees.skillLevels[id] > 0);
			skillTrees.connet[connetedskill].SetActive(skillTrees.skillLevels[id] > 0);
		}
	}

	public void Buy()
	{
		if (skillTrees.skillPoint < 1 || skillTrees.skillLevels[id] >= skillTrees.skillCaps[id])
			return;
		skillTrees.skillPoint -= 1;
		skillTrees.skillLevels[id]++;
		skillTrees.UpdateAllSkillUI();

	}
}
