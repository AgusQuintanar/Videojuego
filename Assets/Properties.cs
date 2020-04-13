using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOpen;

    void Start()
    {
        if(isOpen){
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
