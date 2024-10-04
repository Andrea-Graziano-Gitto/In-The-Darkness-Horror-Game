using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interagiscifinale : MonoBehaviour, IInteractable
{
    public GameObject Canvas;
    public GameObject player;
    public GameObject finale;
    public GameObject cervello;
    private FirstPersonController fpc; // Riferimento al FirstPersonController
    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            fpc = player.GetComponent<FirstPersonController>();
        }
    }
    public void Azione()
    {
        fpc.ToggleCursorLock(); // Cambia lo stato del blocco del cursore
        Canvas.SetActive(true);
        finale.SetActive(true);
        if(cervello != null) cervello.SetActive(true);
        player.SetActive(false);
        Destroy(gameObject);
        
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
