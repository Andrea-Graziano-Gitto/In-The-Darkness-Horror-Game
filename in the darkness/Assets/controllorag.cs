using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllorag : MonoBehaviour, IInteractable
{
    public bool lifted;
    public Transform originalParent;
    public GameObject placeholderParent;
    public bool delay;
    private Rigidbody rb;
    public bool connecting;
    public GameObject visibleObject;  // The visible object
    public GameObject backupObject;   // The invisible backup object
    public GameObject connettore;
    public GameObject flare;
    public bool animation;
    public GameObject rag;
    public Collider myCollider;
    public GameObject preEvent;
    public GameObject Event;
    public GameObject Audioop;
    public GameObject bollicine;

    void Start()
    {
       
        animation = false;
        flare.SetActive(false);
        originalParent = transform.parent;
        delay = false;
        connecting = false;
        lifted = false;
        rb = GetComponent<Rigidbody>();

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == connettore)
        {
            animation = true;
            flare.SetActive(false);
            connecting = true;
            lifted = false;
            transform.parent = originalParent;

            // Abilita la gravità

            Invoke("Delayed", 0.2f);
        }
    }

    public void Azione()
    {
        if (!rag.activeSelf && preEvent != null && preEvent.activeSelf)
        {
            if (lifted && !connecting)
            {
                lifted = false;
                flare.SetActive(false);
                transform.parent = originalParent;
                rb.isKinematic = false; // Rendi l'oggetto non kinematic
                rb.useGravity = true; // Abilita la gravità
                rb.constraints = RigidbodyConstraints.None; // Rimuovi tutti i constraints
                Invoke("Delayed", 0.2f);
            }

            if (!delay && !connecting)
            {
                flare.SetActive(true);

                lifted = true;
                transform.parent = placeholderParent.transform;
                rb.isKinematic = true; // Rendi l'oggetto kinematic
                rb.useGravity = false; // Disabilita la gravità
                rb.constraints = RigidbodyConstraints.FreezeAll; // Blocca tutti i constraints di rotazione e movimento
                delay = true;
            }
        }
        if (rag.activeSelf && preEvent != null && preEvent.activeSelf)
        {
            bollicine.SetActive(true);
            rag.SetActive(false);
            if (Audioop != null) Instantiate(Audioop, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            Event.SetActive(true);
            myCollider.enabled = true;
        }

    }

    public void Delayed()
    {
        delay = false;
    }

    void Update()
    {



        if (animation)
        {

            // Smoothly interpolate position and rotation
            visibleObject.transform.position = Vector3.Lerp(
                visibleObject.transform.position,
                backupObject.transform.position,
                Time.deltaTime * 2f
            );

            visibleObject.transform.rotation = Quaternion.Lerp(
                visibleObject.transform.rotation,
                backupObject.transform.rotation,
                Time.deltaTime * 2f
            );

            // Check if the visible object is close enough to the backup object's position and rotation
            if (Vector3.Distance(visibleObject.transform.position, backupObject.transform.position) < 0.01f &&
                Quaternion.Angle(visibleObject.transform.rotation, backupObject.transform.rotation) < 1.0f)
            {
                // Stop the transition
                animation = false;
            }


        }


    }
}
