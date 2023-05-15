using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillTrees : MonoBehaviour
{
    public static SkillTrees skillTrees;
	private void Awake() => skillTrees = this;

	public int[] skillLevels;
	public int[] skillCaps;
	public string[] skillNames;

	public GameObject skill;
	public List<Skill> skillList;
	public GameObject skillHolder;

	public List<GameObject> connet;
	public GameObject connetHolder;
	private bool isopen = false;

	public int skillPoint;
	
	private void Start()
	{
		skillPoint = 0;
		skillLevels = new int[4];
		skillCaps = new[] { 1, 2, 1, 2 };

		skillNames = new[] { "L1", "R1", "L2", "R2" };


		foreach (var skill in skillHolder.GetComponentsInChildren<Skill>()) skillList.Add(skill);
		foreach(var connetor in connetHolder.GetComponentsInChildren<RectTransform>())	connet.Add(connetor.gameObject);
		for (var i = 0; i < skillList.Count; i++)	skillList[i].id = i;
		
		skillList[0].connectedUpgrades = new[] { 1 };
		skillList[2].connectedUpgrades = new[] { 3 };

		UpdateAllSkillUI();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			isopen = !isopen;
			if (isopen)
				Open();
			else
				Close();
		}
	}
	private void Close()
	{
		skill.SetActive(true);
	}

	private void Open()
	{
		skill.SetActive(false);
	}

	public void UpdateAllSkillUI()
	{
		foreach (var skill in skillList)
			skill.UIUpdate();
	}
	


}
