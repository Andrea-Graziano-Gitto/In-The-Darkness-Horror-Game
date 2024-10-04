using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEquip : MonoBehaviour
{
    // Variabile per memorizzare lo stato attivo del GameObject
    private bool isActive;
    public GameObject equip;
    void Start()
    {
        // Imposta lo stato iniziale del GameObject
        isActive = equip.activeSelf;
    }

    void Update()
    {
        // Controlla se il tasto "L" è stato premuto
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Alterna lo stato del GameObject
            isActive = !isActive;
           equip.SetActive(isActive);
        }
    }

}
