using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : Entry
{
	
	private Enemy enemy;
	public GameManager manager;
	private Rigidbody rb;
	[SerializeField]
	private Transform characterBody;
	[SerializeField]
	private Transform cameraArm;
	public Animator anim;
	public GameObject attackCollision;
	public float speed = 6.0f;
	public int maxhp;
	public int currenthp;
	public bool isdamage;
	private SpriteRenderer spriteRender;
	public ParticleSystem skill;
	public ParticleSystem slash;
	public ParticleSystem hPPotion;
	public ParticleSystem mPPotion;
	private InventoryController inventory;
	public AudioClip meteor;
	public AudioClip Level;
	public AudioClip Hit;
	public AudioClip Slash;
	public AudioClip Slash2;
	public AudioClip Heal;
	
	public int Player_Lv;
	public float Current_XP;
	public float Max_XP = 100;

	public Image xp_bar;
	public TextMeshProUGUI level;
	
	void Start()
	{
		
		anim = characterBody.GetComponent<Animator>();
		spriteRender = GetComponent<SpriteRenderer>();
		enemy = GetComponent<Enemy>();
		inventory = GetComponent<InventoryController>();
		base.SetUp();
		
	}

	void Update()
	{
		level.text = "LEVEL " + Player_Lv;
		xp_bar.fillAmount = Current_XP / Max_XP;
		Player_XP();
		LookAround();
		Move();
		Skill();
		Die();
		Potion();
		Level_Up();

		
			
		
	}


	public void Skill()	
	{
		
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit ,100f))
			{
				skill.transform.position = hit.point;
				skill.Play();
			}
			MP -= 20;
			SoundManager.instance.SFXPlay("Meteor", meteor);
			
		}
		
	}


	public void Player_XP()
	{
		Max_XP = Player_Lv * 100;
	}

	public void Level_Up()
	{
		if(Current_XP>=Max_XP)
		{
			Current_XP -= Max_XP;
			Player_Lv++;
			Player_XP();
			FindObjectOfType<SkillTrees>().skillPoint++;
			SoundManager.instance.SFXPlay("Level", Level);
		}
		

	}

	public override float MaxHp => MaxHpBasic * MaxHpAttrBonus;
	public float MaxHpBasic => 2;
	public float MaxHpAttrBonus => 10 * 10;

	public override float HPRecovery => 0;
	public override float MaxMp => 200;
	public override float MPRecovery => 0.5f;

	public override void TakeDamage(float damage)
	{
		HP -= damage;
		anim.SetTrigger("isDamage");
	}

	private void OnTriggerEnter(Collider other )
	{
		if (other.tag == "Enemy")
		{
			if (!isdamage)
			{
				//Fireball enemyBullet = other.GetComponent<Fireball>();
				currenthp -= 10;
				HP -= 10;
				CameraShake.Instance.OnShakeCamera(0.1f, 0.5f);
				if (other.GetComponent<Rigidbody>() != null)
					Destroy(other.gameObject);
				
				
				StartCoroutine(OnDamage());
				

				
			}
			
		}
		

	}

	private void OnParticleCollision(GameObject other)
	{
		if (other.tag == "Particle")
		{
			if (!isdamage)
			{
				HP -= 10;
				currenthp -= 10;
				anim.SetTrigger("isDamage");
			}
				
		}
	}
	
	public void Potion()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{

			hPPotion.transform.position = characterBody.transform.position;
			
			hPPotion.Play();
			HP += 50;
			SoundManager.instance.SFXPlay("Heal", Heal);

		}
		
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{

			mPPotion.transform.position = characterBody.transform.position;
			mPPotion.Play();
			MP += 50;
			SoundManager.instance.SFXPlay("Heal", Heal);
		}
		
	}
		
	

	IEnumerator OnDamage()
	{
		isdamage = true;
		//anim.SetTrigger("isDamage");
		yield return new WaitForSeconds(1.0f);
		SoundManager.instance.SFXPlay("Hit", Hit);
		isdamage = false;

	}
	
	void Die()
	{
		if (HP < 1)
		{
			anim.SetTrigger("isDie");

			isdamage = true;

			StopAllCoroutines();
		}
	}
	private void Move()
	{
		Vector2 moveInput =  new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		
		bool ismove = moveInput.magnitude != 0;
		anim.SetBool("ismove", ismove);
		if(ismove)
		{
			Vector3 lookForward = new Vector3(cameraArm.forward.x, 0.0f, cameraArm.forward.z).normalized;
			Vector3 lookRight = new Vector3(cameraArm.right.x, 0.0f, cameraArm.right.z).normalized;
			Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
			characterBody.forward = moveDir;
			transform.position += moveDir * Time.deltaTime * speed;
			
		}

		if(Input.GetMouseButtonDown(1))
		{
			anim.SetTrigger("OnAttack");
			slash.transform.position = attackCollision.transform.position;
			slash.transform.rotation = attackCollision.transform.rotation;
			slash.Play();
			SoundManager.instance.SFXPlay("Slash", Slash);
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			anim.SetTrigger("OnAttacking");
			MP -= 10;
			slash.transform.position = attackCollision.transform.position;
			slash.transform.rotation = attackCollision.transform.rotation;
			slash.Play();
			SoundManager.instance.SFXPlay("Slash2", Slash2);
		}

		
	}


	
	private void LookAround()
	{
		Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		Vector3 camAngle = cameraArm.rotation.eulerAngles;
		float x = camAngle.x - mouseDelta.y;

		if(x<180.0f)
		{
			x = Mathf.Clamp(x, -1.0f, 70f);
		}
		else
		{
			x = Mathf.Clamp(x, 335.0f, 361.0f);
		}
		cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
	}

	
}
