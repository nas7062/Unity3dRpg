using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entry : MonoBehaviour
{
	private Stats stats; // ĳ���� ����
	public Entry target; // ���ݴ��(�÷��̾�� ����� Ŭ���ϴ� ���
    // Start is called before the first frame update

	public float HP
	{
		set => stats.HP = Mathf.Clamp(value, 0, MaxHp);
		get => stats.HP;
	}
	public float MP
	{
		set => stats.MP = Mathf.Clamp(value, 0, MaxMp);
		get => stats.MP;
	}

	public abstract float MaxHp { get; }
	public abstract float HPRecovery { get; }
	public abstract float MaxMp { get; }
	public abstract float MPRecovery { get; }
	

	protected void SetUp()
	{
		HP = MaxHp;
		MP = MaxMp;

		StartCoroutine(Recovery());
	}

	
	protected IEnumerator Recovery()
	{
		while(true)
		{
			if (HP < MaxHp)
				HP += HPRecovery;
			if (MP < MaxMp)
				MP += MPRecovery;

			yield return new WaitForSeconds(1.0f);
		}
	}

	public abstract void TakeDamage(float damage);

[System.Serializable]
public struct Stats
{
		[HideInInspector]
		public float HP;
		[HideInInspector]
		public float MP;

}


}
