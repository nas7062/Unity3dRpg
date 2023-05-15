using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionItem : MonoBehaviour
{

    private Player player;
  
    [SerializeField]
    private Text actionText;

	private void Awake()
	{
        player = FindObjectOfType<Player>();
	}


	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
		{

             int gg = UnityEngine.Random.Range(20, 100);
            player.Gold += gg;
            actionText.text = "Gold " + gg + " È¹µæ ";
            actionText.gameObject.SetActive(true);
            Destroy(gameObject);
            StartCoroutine(TextClone());
        }
       
    }

    IEnumerator TextClone()
	{
        yield return new WaitForSeconds(2.0f);

        actionText.gameObject.SetActive(false);
	}




	


	
}
