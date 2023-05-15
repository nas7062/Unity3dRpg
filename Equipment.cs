using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{


	public GameObject equipment;

	private bool isopen = false;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			isopen = !isopen;
			if (isopen)
				Open();
			else
				Close();
		}
	}
	private void Close()
	{
		equipment.SetActive(true);
	}

	private void Open()
	{
		equipment.SetActive(false);
	}

}
