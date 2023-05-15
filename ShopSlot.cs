using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopSlot : MonoBehaviour
{
    private Player player;
    private InventoryController inventory;
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    public TextMeshProUGUI itemAmount;
    public Sprite image;
    public GameObject itemBuy;
    public int _itemAmount;
    public TextMeshProUGUI buyPrice;
    public QuestGive quest;
	void Start()
	{
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<InventoryController>();
        itemName.text = itemBuy.GetComponent<Spwan>().itemName;
        itemImage.sprite = itemBuy.GetComponent<Image>().sprite;
        buyPrice.text = itemBuy.GetComponentInChildren<Spwan>().itemPrice + " WON";
        quest = FindObjectOfType<QuestGive>();
	}
	// Update is called once per frame
	void Update()
    {
        itemAmount.text = "Amount: " + _itemAmount.ToString();
        
    }
    public void Buy()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slot>().amount < 20
                 && player.Gold >= itemBuy.GetComponentInChildren<Spwan>().itemPrice && _itemAmount > 0)
            {
                if (itemName.text == inventory.slots[i].transform.GetComponentInChildren<Spwan>().itemName)
                {
                    _itemAmount -= 1;
                    inventory.slots[i].GetComponent<Slot>().amount += 1;
                    player.Gold -= itemBuy.GetComponentInChildren<Spwan>().itemPrice;
                    quest.GetComponent<QuestGive>().minidescript += 1;
                    quest.GetComponent<QuestGive>().minicurrent.text = quest.GetComponent<QuestGive>().minidescript.ToString();
                    break;
                }


            }
            else if(inventory.isFull[i]== false && player.Gold 
                >= itemBuy.GetComponentInChildren<Spwan>().itemPrice && _itemAmount > 0)
			{
                _itemAmount -= 1;
                player.Gold -= itemBuy.GetComponentInChildren<Spwan>().itemPrice;
                inventory.slots[i].GetComponent<Slot>().itemName = itemName.text;
                inventory.isFull[i] = true;
                Instantiate(itemBuy, inventory.slots[i].transform, false);
                inventory.slots[i].GetComponent<Slot>().amount += 1;
                quest.GetComponent<QuestGive>().minidescript += 1;
                quest.GetComponent<QuestGive>().minicurrent.text = quest.GetComponent<QuestGive>().minidescript.ToString();
                break;
			}
        }
        
    }
    public void Sell()
	{
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if ( inventory.slots[i].transform.GetComponent<Slot>().amount != 20)
                 
            {
                if (itemName.text == inventory.slots[i].transform.GetComponentInChildren<Spwan>().itemName)
                {
                    _itemAmount += 1;
                    inventory.slots[i].GetComponent<Slot>().amount -= 1;
                    player.Gold += itemBuy.GetComponentInChildren<Spwan>().itemPrice /2;
                    if(inventory.slots[i].GetComponent<Slot>().amount ==0)
					{
                        inventory.slots[i].GetComponent<Slot>().itemName = string.Empty;
                        GameObject.Destroy(inventory.slots[i].transform.GetComponentInChildren<Spwan>().gameObject);
					}

                    break;
                }


            }
           
        }
    }
}
