using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillCoolTime : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI textInfo;
	[SerializeField]
	private TextMeshProUGUI textCoolTime;
	[SerializeField]
	private Image CoolTimeImage;
	[SerializeField]
	private string SkillName;
	[SerializeField]
	private float maxCoolTime;

	private float currentCoolTime;

	private bool isCoolTime;

	private void Awake()
	{
		SetCoolTime(false);
	}

	
	public void StartCoolTime()
	{
	//	if(isCoolTime == true)
	//	{
	//		textInfo.text = $"{SkillName} coolTime : {currentCoolTime.ToString("F1")}";
	//		return;
	//	}
	//	textInfo.text = $"Use Skill : {SkillName}";

		StartCoroutine("OnCoolTime", maxCoolTime);
	}


	IEnumerator OnCoolTime(float maxCoolTime)
	{
		currentCoolTime = maxCoolTime;

		SetCoolTime(true);

		while(currentCoolTime >0)
		{
			currentCoolTime -= Time.deltaTime;

			CoolTimeImage.fillAmount = currentCoolTime / maxCoolTime;

			textCoolTime.text = currentCoolTime.ToString("F1");

			yield return null;
		}

		SetCoolTime(false);
	}

	private void SetCoolTime(bool boolean)
	{
		isCoolTime = boolean;
		textCoolTime.enabled = boolean;
		CoolTimeImage.enabled = boolean;

	}
	
}
