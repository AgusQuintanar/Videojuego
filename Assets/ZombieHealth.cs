using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    bool isDead = false;


    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
        else
        {
            // todo poner random shot index
            GetComponent<ZombieAI>().ZombieGettingShot();
            GetComponent<Animator>().SetTrigger("shot");
            GetComponent<Animator>().SetBool("run", true);
            GetComponent<ZombieAI>().StartRunning();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        // todo poner die index
        GetComponent<Animator>().SetTrigger("die");


    }

    public void DeleteZombie()
    {
        Destroy(gameObject);
    }
}
