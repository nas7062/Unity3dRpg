using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SkillInput : MonoBehaviour
{
	[SerializeField]
	private GraphicRaycaster graphicRaycaster;
	[SerializeField]
	private SkillCoolTime[] skillCoolTimes;

	private List<RaycastResult> raycastResults;
	private PointerEventData pointerEventData;

	private void Awake()
	{
		raycastResults = new List<RaycastResult>();
		pointerEventData = new PointerEventData(null);
	}

	private void Update()
	{
		for(int i =0;i<skillCoolTimes.Length;i++)
		{
			if(Input.GetKeyDown((i+1).ToString()))
			{
				skillCoolTimes[i].StartCoolTime(); 
			}
		}

		if(Input.GetMouseButtonDown(0))
		{
			raycastResults.Clear();

			pointerEventData.position = Input.mousePosition;
			graphicRaycaster.Raycast(pointerEventData, raycastResults);

			if(raycastResults.Count >0)
			{

				SkillCoolTime coolTime = raycastResults[0].gameObject.GetComponent<SkillCoolTime>() as SkillCoolTime;
				if(coolTime !=null)
				{
					coolTime.StartCoolTime();
				}
			}
		}


	}

	

}
