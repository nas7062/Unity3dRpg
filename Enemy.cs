using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : Entry
{
    public enum Type { a,b,c,d};
    public Type enemyType;
    public int max;
    public int current;
    public Transform Target;
    public bool isAttack;
    public BoxCollider attackcollider;
    public int currentkill;
    public Animator anim;
	public GameObject bullet;
    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(-0.5f, 2.5f, 0);
    public Canvas HpCanvas;
    public Slider enemyhpLSlider;
	Rigidbody rigid;
    public BoxCollider boxCollider;
    public NavMeshAgent nav;
    Material mat;
    public bool isDead;
    public bool isdamage;
    PlayerController player;
     EnemyHPUI enemyhp;

    public GameObject money;
    
    // Start is called before the first frame update
    public void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<MeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        enemyhp = GetComponent<EnemyHPUI>();
        player = FindObjectOfType<PlayerController>();
        base.SetUp();

      //  SetHpBar();
    }

	void Update()
	{
        if(nav.enabled)
		{
            nav.SetDestination(Target.position);
        }

        
    }   

    public void SetHpBar()
	{
        HpCanvas = GameObject.Find("Enemy Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, HpCanvas.transform);
        var _hpbar = hpBar.GetComponent<EnemyHPBar>();
        _hpbar.targetTransform = this.gameObject.transform;
        _hpbar.offset = hpBarOffset;

	}

    
    public override float MaxHp => MaxHpBasic * MaxHpAttrBonus;
    public float MaxHpBasic => 1;
    public float MaxHpAttrBonus => 10;

    public override float HPRecovery => 0;
    public override float MaxMp => 200;
    public override float MPRecovery => 0;



	private void OnParticleCollision(GameObject other)
	{
       

        if (other.tag == "Particle")
        {
            if (!isdamage)
            {

              
                anim.SetTrigger("OnHit");

                hpBarPrefab.SetActive(true);
                Vector3 reactVec = transform.position - other.transform.position;

                StartCoroutine(OnHitColor(reactVec));



                current -= 10;
             //   int damage = 10;
              //
              //target.TakeDamage(damage);
              //  HP -= damage;
            }

        }
    }
	public override void TakeDamage(float damage)
    {
        HP -= damage;
        
    }

    public void OnTriggerEnter(Collider other)
	{
		if(other.tag =="Weapone")
		{
            if (!isdamage)
            {
                AttackCollision weapone = other.GetComponent<AttackCollision>();
                CameraShake.Instance.OnShakeCamera(0.1f, 0.5f);
                
                anim.SetTrigger("OnHit");

                hpBarPrefab.SetActive(true);
                Vector3 reactVec = transform.position - other.transform.position;

                StartCoroutine(OnHitColor(reactVec));

                
                
                current -= 10;
                int damage = 10;
                target.TakeDamage(damage);
                HP -= damage;

                
            }
          
        }
	}

	void FreezeVelocity()
	{
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
	}

    void TargetTing()
	{
        float targetRadius = 1.5f;
        float targetRange = 3.0f;

		switch (enemyType)
		{
            case Type.a:
                 targetRadius = 1.5f;
                 targetRange = 10.0f;
                break;
            case Type.b:
                targetRange = 5.0f;
                break;
            case Type.c:
                targetRadius = 0.5f;
                targetRange = 30.0f;
                break;
            case Type.d:
                targetRadius = 0.5f;
                targetRange = 30.0f;
                break;


        }

		RaycastHit[] raycastHits =
            Physics.SphereCastAll(transform.position, targetRadius, transform.forward,
            targetRange, LayerMask.GetMask("Player"));

        if(raycastHits.Length> 0 && !isAttack)
		{
            StartCoroutine(Attack());
		}

	}

    IEnumerator Attack()
	{
        isAttack = true;
        anim.SetBool("isAttack", true);

        switch (enemyType)
        {
            case Type.a:
              
                break;
            case Type.b:
                yield return new WaitForSeconds(0.8f);
                attackcollider.enabled = true;
                yield return new WaitForSeconds(1.0f);
                attackcollider.enabled = false;
                
                break;
            case Type.c:
                yield return new WaitForSeconds(0.5f);
                GameObject instantBullet = Instantiate(bullet, transform.position +Vector3.up, transform.rotation);
                Rigidbody rigidbullet = instantBullet.GetComponent<Rigidbody>();
                rigidbullet.velocity = transform.forward * 20;
                   
                yield return new WaitForSeconds(1.0f);
                break;
        

        }
        

        isAttack = false;
        anim.SetBool("isAttack", false);
        
    }

    void FixedUpdate()
	{
        TargetTing();
        FreezeVelocity();
	}
    

	private IEnumerator OnHitColor(Vector3 reactVec)
	{
         mat.color= Color.red;
        isdamage = true;
        reactVec = reactVec.normalized;
        reactVec += Vector3.up;
        yield return new WaitForSeconds(1.5f);
        rigid.AddForce(reactVec * 3, ForceMode.Impulse);

        if (current == 0)
        {
            isDead = true;

            anim.SetTrigger("DoDie");
            StopAllCoroutines();
            mat.color = Color.gray;
            player.Current_XP += 50;
            player.Level_Up();
            Destroy(gameObject, 3.0f);
            Instantiate(money, transform.position, Quaternion.identity);
        }
        

        isdamage = false;
       
    }

	
}
