using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject miniBoss;
    [SerializeField] Transform[] spawns;
    [SerializeField] GameObject[] characters;
    [SerializeField] Transform target;
    IEnumerator generateZombie;
    int randomSpawnIndex, randomCharacterIndex;

    int spawnIndex;


    void Start()
    {
        generateZombie = GenerateZombie();
        StartCoroutine(generateZombie);

        StartCoroutine(GenerateMiniboss());

    }

    IEnumerator GenerateZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            randomSpawnIndex = Random.Range(0, spawns.Length); 
            GameObject newZombie = Instantiate(zombie, spawns[randomSpawnIndex].position , Quaternion.identity);
            randomCharacterIndex = Random.Range(0, 15);  //todo poner random  
            //characters[randomCharacterIndex].transform.parent = newZombie.transform;
            newZombie.GetComponent<ZombieAI>().target = target;
        }
        

    }

    IEnumerator GenerateMiniboss()
    {
        while (true)
        {
            yield return new WaitForSeconds(100f);

            randomSpawnIndex = Random.Range(0, spawns.Length);
            GameObject newZombie = Instantiate(miniBoss, spawns[randomSpawnIndex].position, Quaternion.identity);
            randomCharacterIndex = Random.Range(0, 15);  //todo poner random  
            //characters[randomCharacterIndex].transform.parent = newZombie.transform;
            newZombie.GetComponent<ZombieAI>().target = target;

        }


    }
}
