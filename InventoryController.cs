using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	[SerializeField]
    public GameObject inventory;
    public bool[] isFull;
	public AudioClip UI;
    public GameObject[] slots;
	private bool isopen = false;

	private void Update()
	{
		Inventory();
	}

	private void Inventory()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			isopen = !isopen;
			if (isopen)
				OpenInventory();
			else
				CloseInventory();
		}
	}

	public void CloseInventory()
	{
		inventory.SetActive(true);
		SoundManager.instance.SFXPlay("UI", UI);
	}

	public void OpenInventory()
	{
		inventory.SetActive(false);
		SoundManager.instance.SFXPlay("UI", UI);
	}
}
