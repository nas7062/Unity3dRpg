using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public GameManager manager;
    public GameObject npc;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            manager.Action(npc);
            
        }
        
    }

	private void OnTriggerExit(Collider other)
	{
       // manager.image.SetActive(false);
	}


	
}
