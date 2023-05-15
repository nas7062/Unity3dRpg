using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    public Image panel;
	float time = 0.0f;
	float F_time = 1.0f;
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine(FadeFlow());
		}
	}
	
	IEnumerator FadeFlow()
	{
		panel.gameObject.SetActive(true);
		time = 0.0f;
		Color alpha = panel.color;
		while(alpha.a <1.0f)
		{
			time += Time.deltaTime / F_time;
			alpha.a = Mathf.Lerp(0, 1, time);
			panel.color = alpha;
			yield return null;
		}
		time = 0.0f;

		yield return new WaitForSeconds(1.0f);

		while(alpha.a >0.0f)
		{
			time += Time.deltaTime / F_time;
			alpha.a = Mathf.Lerp(1, 0, time);
			panel.color = alpha;
			yield return null;
		}
		panel.gameObject.SetActive(false);
		yield return null;
	}
}
