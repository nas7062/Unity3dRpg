using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    
    private PlayerController player;
    void Start()
    {
        if (player == null)
            player = FindObjectOfType<PlayerController>();
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
