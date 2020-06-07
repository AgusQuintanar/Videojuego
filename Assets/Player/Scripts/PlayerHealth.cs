using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] Text healthText;

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
}
