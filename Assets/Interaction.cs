using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Interaction : MonoBehaviour
{
    GameObject doorInFront;
    bool stairInFront;
    [SerializeField] Image door_tooltip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessDoor();
        ProcessStair();
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Door"){
            doorInFront = collision.gameObject;
            print("new door");
            if (door_tooltip != null) door_tooltip.gameObject.SetActive(true);
        }
        if(collision.gameObject.tag == "Stair"){
            stairInFront = true;
            print("stair");
        }
    }

    void OnTriggerExit(Collider collision){
        if(collision.gameObject.tag == "Door"){
            doorInFront = null;
            print("deleted door");
            if (door_tooltip != null) door_tooltip.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Stair"){
            stairInFront = false;
            print("stair exit");
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

    
}
