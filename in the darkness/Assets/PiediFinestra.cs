using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiediFinestra : MonoBehaviour, IInteractable
{

    public bool isPlayerInZone = false;
    public bool isOpening, isClosing;
    public bool aperta = false;
    public GameObject Audioop;
    public GameObject Audiocl;
    public Vector3 portachiusa;
    public Vector3 portaaperta;

    public float transitionSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        portachiusa = new Vector3(1.022078f, 2.447306f, -4.913874f);
        portaaperta = new Vector3(-0.45f, 2.447306f, -4.913874f);
    }

    void OnTriggerEnter(Collider other)
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
        
        if (aperta && !isOpening)
        {
            
            chiusura();
            if (Audiocl != null) Instantiate(Audiocl, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            return;
        }

        if (!aperta && isPlayerInZone && !isClosing)
        {
            
            apertura();
            if (Audioop != null) Instantiate(Audioop, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            return;
        }
    }

    public void chiusura()
    {
        Debug.Log("chiudendo");
        aperta = false;
        isOpening = false;
        isClosing = true;
    }


    public void apertura()
    {
        Debug.Log("aprendo");
        aperta = true;
        isClosing = false;
        isOpening = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClosing)
        {
            // Smoothly interpolate position and rotation
            gameObject.transform.position = Vector3.Lerp(
                gameObject.transform.position,
                portachiusa,
                Time.deltaTime * transitionSpeed
            );

            // Check if the visible object is close enough to the backup object's position and rotation
            if (Vector3.Distance(gameObject.transform.position, portachiusa) < 0.01f)
            {
                // Stop the transition
                isClosing = false;
            }
        }

        if (isOpening)
        {
            // Smoothly interpolate position and rotation
            gameObject.transform.position = Vector3.Lerp(
                gameObject.transform.position,
                portaaperta,
                Time.deltaTime * transitionSpeed
            );

            // Check if the visible object is close enough to the backup object's position and rotation
            if (Vector3.Distance(gameObject.transform.position, portaaperta) < 0.01f)
            {
                // Stop the transition
                isOpening = false;
            }
        }


    }
}
