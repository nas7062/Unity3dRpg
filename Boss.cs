using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss : Enemy
{
    public GameObject fireball;
    public Transform fireballPort;
    Vector3 Look;
    Vector3 taunt;
    public  bool isLook;
    public ParticleSystem fire;
    private QuestGive quest;
    public AudioClip boss;
    float dist;


	
	void Start()
    {
        StartCoroutine(Attack());
        nav.isStopped = true;
        base.SetUp();
    }

   
    // Update is called once per frame
    void Update()
    {
        if(isDead)
		{
            StopAllCoroutines();
            anim.SetTrigger("DoDie");
            quest.minidescript += 1;
            return;
		}
        if(isLook)
		{
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Look = new Vector3(h, 0, v) * 5f;
            transform.LookAt(Target.position + Look);
		}
        else
		{
            nav.SetDestination(taunt);
		}
    }


    public override float MaxHp => MaxHpBasic * MaxHpAttrBonus;
    public new float MaxHpBasic => 1;
    public new float MaxHpAttrBonus => 10 * 10;

    public override float HPRecovery => 0.0f;
    public override float MaxMp => 100;
    public override float MPRecovery => 0.5f;
    IEnumerator Attack()
	{
        yield return new WaitForSeconds(1.0f);
        dist = Vector3.Distance(Target.transform.position, fireballPort.transform.position);
        SoundManager.instance.SFXPlay("Boss", boss);
        int randomAction = Random.Range(0, 3);
        if (dist < 5)
		{
            StartCoroutine(TailAttack());
		}
        else
		{
            switch (randomAction)
            {

                case 0:
                    StartCoroutine(Fireball());
                    break;
                case 1:
                    StartCoroutine(Fire());
                    break;
                case 2:
                    StartCoroutine(Taunt());
                    break;
                


            }
        }


        hpBarPrefab.SetActive(true);

    }

    IEnumerator Fireball()
	{
        anim.SetTrigger("DoFire");
        yield return new WaitForSeconds(0.5f);
        GameObject instantFireball = Instantiate(fireball, fireballPort.position + Vector3.up, fireballPort.rotation);
        BossFireball bossFireball = instantFireball.GetComponent<BossFireball>();
        Rigidbody rigidbullet2 = bossFireball.GetComponent<Rigidbody>();
        rigidbullet2.velocity = transform.forward * 20;
        bossFireball.target = Target;
        yield return new WaitForSeconds(2.5f);

        StartCoroutine(Attack());
    }
    IEnumerator TailAttack()
	{
        anim.SetTrigger("DoTail");
        yield return  new WaitForSeconds(2.5f);
        StartCoroutine(Attack());
    } 
    IEnumerator Taunt()
	{
        taunt = Target.position + Look;
        isLook = false;
        nav.isStopped = false;
        boxCollider.enabled = false;
        anim.SetTrigger("DoLand");
        yield return new WaitForSeconds(1.5f);
        attackcollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        attackcollider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        isLook = true;
        nav.isStopped = true;
        boxCollider.enabled = true;
        StartCoroutine(Attack());
    }

    IEnumerator Fire()
	{
       
        anim.SetTrigger("DoFly");
        yield return new WaitForSeconds(0.5f);
        fire.transform.position = fireballPort.transform.position;
        fire.transform.rotation = fireballPort.transform.rotation;
        fire.Play();
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Attack());
    }
}
