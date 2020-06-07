using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private bool canUseComputer = false;
    private Transform computerCanvas;

    void Start()
    {
        computerCanvas = transform.Find("Computer Canvas");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.C) && !InventoryManager.INSTANCE.hasInventoryCurrentlyOpen() && canUseComputer)
        {
            InventoryManager.INSTANCE.DisableAll();
            computerCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUseComputer= true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUseComputer = false;
        }
    }
}
