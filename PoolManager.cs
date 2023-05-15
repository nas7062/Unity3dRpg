using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;


	private void Awake()
	{
		pools = new List<GameObject>[prefabs.Length];

		for(int i =0; i< pools.Length;i++)
		{
			pools[i] = new List<GameObject>();

		}
	}

	public GameObject Get(int idx)
	{
		GameObject select = null;

		foreach(GameObject enemy in pools[idx])
		{
			if(!enemy.activeSelf)
			{
				select = enemy;
				select.SetActive(true);
				break;
			}
		}

		if(!select)
		{
			select = Instantiate(prefabs[idx], transform);
			pools[idx].Add(select);

		}

		return select;
	}
}
