using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Interaction : MonoBehaviour
{
    GameObject doorInFront;
    bool stairInFront;
    [SerializeField] Image tooltip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessDoor();
        ProcessStair();

        if (InventoryManager.INSTANCE.hasInventoryCurrentlyOpen()) if (tooltip != null) tooltip.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Door")
        {
            doorInFront = c.gameObject;
            if (tooltip != null)
            {
                tooltip.gameObject.SetActive(true);
                tooltip.GetComponentInChildren<Text>().text = "Presione [X] para abrir/cerrar puerta";
            }
        }
        else if(c.gameObject.tag == "Stair")
        {
            stairInFront = true;
            print("stair");
        }
        else if (c.gameObject.tag == "Dresser")
        {
            if (tooltip != null)
            {
                tooltip.gameObject.SetActive(true);
                tooltip.GetComponentInChildren<Text>().text = "Presione [C] para examinar el Tocador";
            }

        }
        else if (c.gameObject.tag == "Wardrobe")
        {
            if (tooltip != null)
            {
                tooltip.gameObject.SetActive(true);
                tooltip.GetComponentInChildren<Text>().text = "Presione [C] para examinar el Armario";
            }

        }
        else if (c.gameObject.tag == "Cabinet")
        {
            if (tooltip != null)
            {
                tooltip.gameObject.SetActive(true);
                tooltip.GetComponentInChildren<Text>().text = "Presione [C] para examinar el Gabinete";
            }

        }
        else if (c.gameObject.tag == "Computer")
        {
            if (tooltip != null);
            {
                tooltip.gameObject.SetActive(true);
                tooltip.GetComponentInChildren<Text>().text = "Presione [C] para usar la Computadora";
            }

        }

    }

    void OnTriggerExit(Collider c){
        if(c.gameObject.tag == "Door")
        {
            doorInFront = null;
            if (tooltip != null) tooltip.gameObject.SetActive(false);
        }
        else if (c.gameObject.tag == "Stair")
        {
            stairInFront = false;
            print("stair exit");
        }
        else if (c.gameObject.tag == "Dresser" || c.gameObject.tag == "Wardrobe" || c.gameObject.tag == "Cabinet" || c.gameObject.tag == "Computer")
        {
            if (tooltip != null) tooltip.gameObject.SetActive(false);
        }
    }

    void ProcessDoor(){
        if(doorInFront == false) return;
        if(Input.GetKeyDown(KeyCode.X)){
            if(doorInFront.GetComponent<Properties>().isOpen){
                print("closing");
                doorInFront.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else{
                print("opening");
                doorInFront.transform.localRotation = Quaternion.Euler(0, 90, 0);
            }
            doorInFront.GetComponent<Properties>().isOpen = !doorInFront.GetComponent<Properties>().isOpen;
        }
    }

    void ProcessStair(){
        if(stairInFront == false) return;
        float translation = Input.GetAxis("Vertical") * Time.deltaTime * 10;
        if(translation < 0){
            translation = 0;
        }
        transform.Translate(0, translation, 0);
        
    }

    public void clearTooltip()
    {
        if (tooltip != null) tooltip.gameObject.SetActive(false);
    }
    
}
