using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maindoorlock : MonoBehaviour, IInteractable
{
    public GameObject Key;
    public Rigidbody rb;
    public GameObject posizionePorta;
    public GameObject visibleObject;  // The visible object
    public GameObject backupObject;   // The invisible backup object
    public GameObject Audioknock;
    public GameObject Audioop;
    public GameObject Audiocl;
    public bool knocktime;

    public float transitionSpeed = 1.0f; // Speed of the transition
    public Vector3 pushForce = new Vector3(1.0f, 0.0f, 0.0f); // Small push force

    private bool isTransitioning = false; // Flag to control the transition

    public void Azione()
    {
        if (Key.activeSelf && !knocktime)
        {
            if (Audioknock != null) Instantiate(Audioknock, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            knocktime = true;
            Invoke("knoc", 1.3f);
        }
        if (!Key.activeSelf)
        {
            if (!rb.isKinematic)
            {
                chiusura();
                return;
            }
            if (rb.isKinematic)
            {
                if (Audioop != null) Instantiate(Audioop, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                Debug.Log("aprendo");
                rb.isKinematic = false;

                // Apply a small push force to the door
                rb.AddForce(pushForce, ForceMode.Impulse);

                return;
            }
        }
    }

    public void knoc()
    {
        knocktime = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        knocktime = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void chiusura()
    {
        isTransitioning = true;
        Debug.Log("chiudendo");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransitioning)
        {
            // Smoothly interpolate position and rotation
            visibleObject.transform.position = Vector3.Lerp(
                visibleObject.transform.position,
                backupObject.transform.position,
                Time.deltaTime * transitionSpeed
            );

            visibleObject.transform.rotation = Quaternion.Lerp(
                visibleObject.transform.rotation,
                backupObject.transform.rotation,
                Time.deltaTime * transitionSpeed
            );

            // Check if the visible object is close enough to the backup object's position and rotation
            if (Vector3.Distance(visibleObject.transform.position, backupObject.transform.position) < 0.01f &&
                Quaternion.Angle(visibleObject.transform.rotation, backupObject.transform.rotation) < 1.0f)
            {
                // Stop the transition
                isTransitioning = false;
                rb.isKinematic = true;
                if (Audiocl != null) Instantiate(Audiocl, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            }
        }
    }
}
