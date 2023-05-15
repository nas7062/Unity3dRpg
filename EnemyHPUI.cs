using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHPUI : MonoBehaviour
{
    public Transform enemy;
    public Slider hpbar;
    public float maxhp;
    public float currenthp;
    public Enemy Enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.position;
        hpbar.value = currenthp / maxhp;

        currenthp = Enemy.current;
    }

	

}
