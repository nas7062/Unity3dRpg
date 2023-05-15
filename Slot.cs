using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Slot : MonoBehaviour
{
	private InventoryController inventory;
	public int idx;
	public TextMeshProUGUI amountText;
	public int amount;
	public string itemName;

	void Start()
	{
		inventory = FindObjectOfType<InventoryController>();
	}
	void Update()
	{

		amountText.text = amount.ToString();

		if(amount>1)
		{
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
		}
		else
		{
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
		}
		
		if(transform.childCount ==5)
		{
			inventory.isFull[idx] = false;
		}
	}

	public void DropItem()
	{
		if(amount>1)
		{
			amount -= 1;
			transform.GetComponentInChildren<Spwan>().SpawnDropItem();
		}
		else
		{
			amount -= 1;
			GameObject.Destroy(transform.GetComponentInChildren<Spwan>().gameObject);
			transform.GetComponentInChildren<Spwan>().SpawnDropItem();
		}
	}
}
