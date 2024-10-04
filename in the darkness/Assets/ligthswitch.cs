using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ligthswitch : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    
    public bool isPlayerInZone = false;
    private bool isActive;
    public GameObject luce;
    public GameObject switc;
    public float adjust;
    public GameObject Audioop;

    void Start()
    {
        isActive = luce.activeSelf;
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            isPlayerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            isPlayerInZone = false;
        }
    }

    public void Azione()
    {
        if (isPlayerInZone)
        {
            if (Audioop != null) Instantiate(Audioop, gameObject.transform.position, Quaternion.identity, gameObject.transform);

            isActive = !isActive;
            luce.SetActive(isActive);
            Debug.Log("L'interruttore della luce viene attivato.");
            if(!isActive) switc.transform.eulerAngles = new Vector3(0f, adjust, 180f);
            if (isActive) switc.transform.eulerAngles = new Vector3(0f, adjust, 0f); 
        }
        // Codice per attivare l'interruttore della luce
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
