using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leggi : MonoBehaviour, IInteractable
{
    public GameObject leggio;
    public GameObject player;
    private bool delay;
    private bool isLeggioActive;
    public GameObject Event;
    public GameObject preEvent;
    public GameObject postEvent;
    public GameObject canPick;
    public GameObject Audioread;
    public GameObject Audiored;
    public GameObject settings;
    private FirstPersonController fpc; // Riferimento al FirstPersonController
    void Start()
    {
        if (player != null)
        {
            fpc = player.GetComponent<FirstPersonController>();
        }
        delay = false;
        isLeggioActive = false;
        leggio.SetActive(false);
        
    }

    public void Azione()
    {
        if (canPick == null || (canPick != null && canPick.activeSelf))
        {
            if (!isLeggioActive && !delay && !settings.activeSelf)
            {

                ActivateLeggio();
                if (Audioread != null) Instantiate(Audioread, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            }
        }
    }

    public void post()
    {
        if (postEvent != null)
        {
            postEvent.SetActive(true);
            postEvent = null;
        }
    }

    private void ActivateLeggio()
    {
        leggio.SetActive(true);
        if(Event != null && preEvent != null && preEvent.activeSelf)Event.SetActive(true);
        
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.enabled = false;
        delay = true;
        isLeggioActive = true;

        // Piccolo ritardo per evitare input multipli
        Invoke("ResetDelay", 0.2f);
    }

    private void DeactivateLeggio()
    {
        leggio.SetActive(false);
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.enabled = true;
        delay = true;
        isLeggioActive = false;
        if (postEvent != null && preEvent != null && preEvent.activeSelf) Invoke("post", 0.001f);
        if (Audiored != null) Instantiate(Audiored, gameObject.transform.position, Quaternion.identity, gameObject.transform);    
        // Piccolo ritardo per evitare input multipli
        Invoke("ResetDelay", 0.2f);
    }

    private void ResetDelay()
    {
        delay = false;
    }

    void Update()
    {
        if (player != null)
        {
            fpc = player.GetComponent<FirstPersonController>();
        }
        if (leggio.activeSelf && fpc.enabled) fpc.enabled = false;
        if (isLeggioActive && Input.GetMouseButtonDown(0) && !delay && !settings.activeSelf)
        {
            DeactivateLeggio();
        }
    }
}
