using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
	public int damage;
	public bool isMelee;
	private PlayerController player;
	private float time = 0.0f;

	private void Start()
	{
		player = FindObjectOfType<PlayerController>();
	}
	void Update()
	{
		transform.Rotate(Vector3.right * 30 * Time.deltaTime);
		time += Time.deltaTime;
	}
	

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag =="Player")
		{
			if (!isMelee)
			{
				player.HP -= 5;
				player.anim.SetTrigger("isDamage");
				CameraShake.Instance.OnShakeCamera(0.1f, 0.5f);
				Destroy(gameObject);
			}
			else if (time >= 3.0f)
			{
				Destroy(gameObject);
			}

		}


	}
}
