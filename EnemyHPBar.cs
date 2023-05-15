using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    private Camera HPCamera;
    private Canvas canvas;
    private RectTransform rectParent;
    private RectTransform rectHp;

    [HideInInspector]
    public Vector3 offset = Vector3.zero;
    [HideInInspector]
    public Transform targetTransform;
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        HPCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void LateUpdate()
	{
        var ScreenPos = Camera.main.WorldToScreenPoint(targetTransform.position + offset);

        if(ScreenPos.z < 0.0f)
		{
            ScreenPos *= -1.0f;
		}

        var LocalPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, ScreenPos, 
            HPCamera, out LocalPos);

        rectHp.localPosition = LocalPos;

	}
}
