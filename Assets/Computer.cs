using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private bool canUseComputer = false;
    private Transform computerCanvas;

    GameObject player;

    private bool computerHasBeenUsed = false;

    void Start()
    {
        computerCanvas = transform.Find("Computer Canvas");
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.C) && !InventoryManager.INSTANCE.hasInventoryCurrentlyOpen() && canUseComputer && !computerHasBeenUsed)
        {


            InventoryManager.INSTANCE.DisableAll();
            computerCanvas.gameObject.SetActive(true);
            computerCanvas.gameObject.GetComponent<Camera>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUseComputer= true;
            if (player == null) player = collision.gameObject;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUseComputer = false;
        }
    }

    public void ComputerHasBeenUsed()
    {
        Debug.Log("holiwis");
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        player.GetComponent<Interaction>().clearTooltip();
        computerHasBeenUsed = true;
        Destroy(this.transform.Find("Lid").transform.Find("Screen").gameObject);
    }

 
}
