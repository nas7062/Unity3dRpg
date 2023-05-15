using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragUi2 : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{

	private Image image2;
	private RectTransform rect2;

	private void Awake()
	{
		image2 = GetComponent<Image>();
		rect2 = GetComponent<RectTransform>();
	}
	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			eventData.pointerDrag.transform.SetParent(transform);
			eventData.pointerDrag.GetComponent<RectTransform>().position = rect2.position;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		image2.color = Color.yellow;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		image2.color = Color.clear;

	}
}
