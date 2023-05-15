using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    public string MapName;
    private PlayerController player;
    void Start()
    {
        if (player == null)
            player = FindObjectOfType<PlayerController>();
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            // player.curretn;
            SceneManager.LoadScene(MapName);
		}
	}
}
