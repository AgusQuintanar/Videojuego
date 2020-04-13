using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    [SerializeField] GameObject zombie;
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

        

    }

    IEnumerator GenerateZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            randomSpawnIndex = Random.Range(0, spawns.Length); 
            GameObject newZombie = Instantiate(zombie, spawns[randomSpawnIndex].position , Quaternion.identity);
            randomCharacterIndex = Random.Range(0, 15);  //todo poner random  
            //characters[randomCharacterIndex].transform.parent = newZombie.transform;
            newZombie.GetComponent<ZombieAI>().target = target;
        }
        

    }
}
