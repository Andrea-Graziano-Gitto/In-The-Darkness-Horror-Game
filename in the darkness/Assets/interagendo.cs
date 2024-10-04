using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interagendo : MonoBehaviour
{
    public bool isPossible = false;
    private GameObject interactableObject;
    public GameObject icon;
    public GameObject iconed;
    public bool tapped;
    public bool stay;


    void Start()
    {
        tapped = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("interact"))
        {
            
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("interact"))
        {
         
            isPossible = false;
            interactableObject = null;
            if(!tapped) icon.SetActive(false);
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("interact"))
        {
            stay = true;
           if(!tapped) icon.SetActive(true);
            isPossible = true;
            interactableObject = other.gameObject;
        }
    }

    void clickedstop()
    {
        iconed.SetActive(false);
        
    }
    void clickstoppi()
    {
        stay = false;
       
    }
    void clickstop()
    {
       
        if (!stay) icon.SetActive(false);
        tapped = false;
    }

    void Update()
    {
        if (isPossible && Input.GetMouseButtonDown(0))
        {
            IInteractable interactable = interactableObject?.GetComponent<IInteractable>();
            if (interactable != null)
            {
                Debug.Log("cazzo");
                iconed.SetActive(true);
                Invoke("clickedstop", 0.2f);
                tapped = true;
                Invoke("clickstoppi", 0.35f);
                Invoke("clickstop", 0.37f);
                interactable.Azione();
            }
        }
    }
}