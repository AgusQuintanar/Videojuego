using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] float damage = 40f;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>(); 
    }

    public void AttackHitEvent()
    {
        if (target == null) return; //if no target
        Debug.Log("banggggggg");
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
        target.TakeDamage(damage);
    }
}
