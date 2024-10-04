using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftableObject : MonoBehaviour, IInteractable
{
    public bool lifted;
    public Transform originalParent;
    public GameObject placeholderParent;
    public bool delay;
    private Rigidbody rb;
    public Collider myCollider;

    void Start()
    {
        originalParent = transform.parent;
        delay = false;
        lifted = false;
        rb = GetComponent<Rigidbody>();
    }

    public void Azione()
    {

        if (lifted)
        {
            lifted = false;
            transform.parent = originalParent;
            rb.isKinematic = false; // Rendi l'oggetto non kinematic
            rb.useGravity = true; // Abilita la gravità
            rb.constraints = RigidbodyConstraints.None; // Rimuovi tutti i constraints
            myCollider.enabled = true;
            Invoke("Delayed", 0.2f);
        }

        if (!delay)
        {
            lifted = true;
            transform.parent = placeholderParent.transform;
            rb.isKinematic = true; // Rendi l'oggetto kinematic
            rb.useGravity = false; // Disabilita la gravità
            rb.constraints = RigidbodyConstraints.FreezeAll; // Blocca tutti i constraints di rotazione e movimento
            delay = true;
            myCollider.enabled = false;
        }
    }

    public void Delayed()
    {
        delay = false;
    }

    void Update()
    {
        
    }
}
