using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragUi : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{

	private Image image;
	private RectTransform rect;

	private void Awake()
	{
		image = GetComponent<Image>();
		rect = GetComponent<RectTransform>();
	}
	public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag !=null)
		{
			eventData.pointerDrag.transform.SetParent(transform);
			eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		image.color = Color.yellow;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		image.color = Color.white;
		
	}
}
