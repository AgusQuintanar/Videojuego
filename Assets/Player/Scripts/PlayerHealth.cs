using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] Text healthText;

    private void Start()
    {
        StartCoroutine(Recover_Health());
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            Debug.Log("You are dead bro");

            //Destroy(gameObject);  //destroys de player

            //SceneManager.LoadScene(2);
        }
    }

    IEnumerator Recover_Health()
    {
        while (true)
        {
            if (health < 100)
            {
                health++;
                healthText.text = health.ToString();
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
