using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public GameObject itemPrefabs;
    private Transform player;
    public string itemName;
    public int itemPrice;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   public void SpawnDropItem()
	{
        Vector3 playerposition = new Vector3(player.position.x, player.position.y+2,
            player.position.z+2);
        Instantiate(itemPrefabs, playerposition, Quaternion.identity);
	}

}
