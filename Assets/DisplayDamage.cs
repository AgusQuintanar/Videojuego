using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.6f;

    void Start()
    {
        impactCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        Debug.Log("hay holaaaaaaaaaaaaaaaaaaaaa 1");
        StartCoroutine(ShowSplatter());
       
    }

    IEnumerator ShowSplatter()
    {
        Debug.Log("hay holaaaaaaaaaaaaaaaaaaaaa 1234");
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }
}
