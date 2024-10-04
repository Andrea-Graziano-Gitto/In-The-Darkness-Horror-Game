using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opensettingingame : MonoBehaviour
{
    public GameObject settingsScreen; // Riferimento alla schermata delle impostazioni
    public GameObject player; // Riferimento al GameObject del giocatore
    private FirstPersonController fpc; // Riferimento al FirstPersonController
    
    private bool isSettingsActive = false; // Stato della schermata delle impostazioni

    void Start()
    {
        if (player != null)
        {
            fpc = player.GetComponent<FirstPersonController>();
        }

        if (settingsScreen != null)
        {
            settingsScreen.SetActive(false); // Assicurati che la schermata delle impostazioni sia nascosta all'inizio
        }
    }

    void Update()
    {
        if (player.activeSelf)
        {
            if(settingsScreen.activeSelf && fpc.enabled) fpc.enabled = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isSettingsActive)
                {
                    // Se la schermata delle impostazioni è già attiva, nascondila e riabilita il controllo del giocatore
                    ToggleSettingsScreen(false);
                }
                else
                {
                    // Altrimenti, mostra la schermata delle impostazioni e disabilita il controllo del giocatore
                    ToggleSettingsScreen(true);
                }
            }
        }
    }

   public void ToggleSettingsScreen(bool show)
    {
       
        if (settingsScreen != null)
        {
            settingsScreen.SetActive(show); // Mostra o nascondi la schermata delle impostazioni
        }

        if (fpc != null)
        {
            fpc.ToggleCursorLock(); // Cambia lo stato del blocco del cursore
            fpc.enabled = !show; // Abilita o disabilita il FirstPersonController in base alla visibilità della schermata
        }

        isSettingsActive = show; // Aggiorna lo stato della schermata delle impostazioni
    }
}
