using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terramovm : MonoBehaviour
{
    public bool animation;
    public bool rimpiazzato;
    public GameObject fioremorto;
    public GameObject visibleObject;
       public GameObject backupObject;
    public GameObject end;
    public Collider myCollider;
    public GameObject Audio;
    // Start is called before the first frame update
    void Start()
    {
        rimpiazzato = false;
        animation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fioremorto == null && !rimpiazzato)
        {
            rimpiazzato = true;
            if (Audio != null) Instantiate(Audio, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            animation = true;
        }
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
                end.SetActive(true);

                myCollider.enabled = false;
            }


        }
    }
}
