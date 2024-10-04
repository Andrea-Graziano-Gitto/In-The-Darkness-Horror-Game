using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertrigger : MonoBehaviour
{
    public GameObject Event;
    public GameObject preEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("player") && preEvent.activeSelf && Event != null)
        {
            Event.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
