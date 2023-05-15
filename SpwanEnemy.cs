using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
	public GameObject enemy;
	public BoxCollider boxCollider;
	public int xPos;
	public int zPos;
	public int enemyCount;
	


	private void Start()
	{
		
		boxCollider = GetComponent<BoxCollider>();
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			StartCoroutine(EnemySpawn());
		}
	}

	IEnumerator EnemySpawn()
	{
		while(enemyCount <3)
		{
			xPos = Random.Range(50,60 );
			zPos = Random.Range(40, 50);
			Instantiate(enemy,new Vector3(xPos,-3,zPos), Quaternion.identity);
			yield return new WaitForSeconds(0.5f);
			enemyCount += 1;
		}
	}


	

}
