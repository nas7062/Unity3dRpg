using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{

	public GameObject attackcollision;
	

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		{
			StartCoroutine(AutoDisable());
		}
	}

	private IEnumerator AutoDisable()
	{
		attackcollision.SetActive(true);
		yield return new WaitForSeconds(1.0f);

		attackcollision.SetActive(false);
	}

}
