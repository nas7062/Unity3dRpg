using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Transform canvas;
    private Transform previousParents;
    private RectTransform rect;
    private CanvasGroup canvasGroup;

	

	private void Awake()
	{
		canvas = FindObjectOfType<Canvas>().transform;
		rect = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}


	public void OnBeginDrag(PointerEventData eventData)
	{
		previousParents = transform.parent;

		transform.SetParent(canvas);
		transform.SetAsLastSibling();

		canvasGroup.alpha = 0.6f;
		canvasGroup.blocksRaycasts = false;
		
	}

	public void OnDrag(PointerEventData eventData)
	{
		rect.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if(transform.parent ==canvas)
		{
			transform.SetParent(previousParents);
			rect.position = previousParents.GetComponent<RectTransform>().position;
		}

		canvasGroup.alpha = 1.0f;
		canvasGroup.blocksRaycasts = true;
	}
}
