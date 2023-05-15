using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRock : Fireball
{
    Rigidbody rigid;
    public float angularPower = 2;
    public float scaleValue = 0.1f;
    public Transform player;
    public bool isShoot;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(RockTimer());
        StartCoroutine(RockPower());
    }

    IEnumerator RockTimer()
	{
        yield return new WaitForSeconds(2.0f);
        isShoot = false;
	}

    IEnumerator RockPower()
    {
        while(!isShoot)
		{

          
            yield return new WaitForSeconds(5.0f);
            Destroy(gameObject);
            isShoot = true;
		}

    }


}
