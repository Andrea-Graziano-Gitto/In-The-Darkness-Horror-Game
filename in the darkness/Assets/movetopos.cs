using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetopos : MonoBehaviour
{
    public GameObject visibleObject;
    public GameObject backupObject;
    public GameObject endanimEvent;
    public GameObject endaimEvent;
    public float transitionSpeed;
    public bool isTransitioning = true;
    // Start is called before the first frame update
    void Start()
    {
        if (endaimEvent != null) endaimEvent.SetActive(true);
        PlayerPrefs.SetInt("load", 1);
        Debug.Log(PlayerPrefs.GetInt("load"));
        PlayerPrefs.Save();
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
               if(endanimEvent != null) endanimEvent.SetActive(true);
              

            }
        }
    }
}
