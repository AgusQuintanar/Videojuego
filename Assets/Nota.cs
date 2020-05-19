using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nota : MonoBehaviour
{
    public GameObject textBox;
    public string[] dialogo;
    public float velocidad = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            StartCoroutine(subs());
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            StopCoroutine(subs());
        }
    }

    IEnumerator subs(){
        for(int i=0; i<dialogo.Length; i++){
            textBox.GetComponent<Text>().text = dialogo[i];
            yield return new WaitForSeconds(dialogo[i].Length/(25*velocidad));
        }
        textBox.GetComponent<Text>().text = "";
    }
}
