using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort : MonoBehaviour
{
    public GameObject player;
    public GameObject teleport;
	public GameObject boss;
	public void OnTriggerEnter(Collider other)
	{
		if(other.tag =="Player")
		{
			StartCoroutine(Teleport());
		}

		boss.SetActive(true);
	}

	IEnumerator Teleport()
	{
		yield return new  WaitForSeconds(0.5f);
		player.transform.position = teleport.transform.position;
	}
}
