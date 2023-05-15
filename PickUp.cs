using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private InventoryController inventory;
    public GameObject itemButton;
    public string itemName;

    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
            for(int i =0;i<inventory.slots.Length;i++)
			{
				if (inventory.isFull[i] == true &&
					inventory.slots[i].transform.GetComponent<Slot>().amount < 2)
				{
					if(itemName == inventory.slots[i].transform.GetComponentInChildren<Spwan>().itemName)
					{
						Destroy(gameObject);
						inventory.slots[i].GetComponent<Slot>().amount += 1;
						break;
					}
				}
				else if(inventory.isFull[i] == false)
				{
					inventory.isFull[i] = true;
					Instantiate(itemButton, inventory.slots[i].transform, false);
					inventory.slots[i].GetComponent<Slot>().amount += 1;
					Destroy(gameObject);
					break;
				}
			}
		}

	}

}
