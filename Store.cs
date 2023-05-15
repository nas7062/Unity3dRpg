using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject Shop;
    private float clickTime = 0;
	// Update is called once per frame


	private void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Shop.SetActive(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		Shop.SetActive(false);
	}





}
