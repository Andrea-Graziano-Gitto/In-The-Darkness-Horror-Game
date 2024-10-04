using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chiavevanish : MonoBehaviour, IInteractable
{
    public GameObject Audio;
    void OnTriggerEnter(Collider other)
    {

    }

    public void Azione()
    {
        gameObject.SetActive(false);
        if (Audio != null) Instantiate(Audio, gameObject.transform.position, Quaternion.identity);
    }

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
