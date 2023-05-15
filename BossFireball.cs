using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossFireball : Fireball
{

    public Transform target;
    NavMeshAgent nav;
	private PlayerController player;
	private float time = 0.0f;
	void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
		player = FindObjectOfType<PlayerController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!isMelee)
			{
				player.HP -= 10;
				player.anim.SetTrigger("isDamage");
				CameraShake.Instance.OnShakeCamera(0.1f, 0.5f);
				Destroy(gameObject);
			}
			else if (time >= 5.0f)
			{
				Destroy(gameObject);
			}
			
		}


	}
}
