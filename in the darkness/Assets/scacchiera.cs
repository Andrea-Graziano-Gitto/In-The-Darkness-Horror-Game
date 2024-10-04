using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scacchiera : MonoBehaviour
{
    public GameObject pezzo;
    public bool occupato;

    void Start()
    {
        occupato = false;
    }

    void Update()
    {
        // Controlla se il pulsante sinistro del mouse è stato premuto
        if (Input.GetMouseButtonDown(0) && pezzo != null)
        {
            // Ottieni il componente ChessPiece dal pezzo
            ChessPiece chessPiece = pezzo.GetComponent<ChessPiece>();

            if (chessPiece != null)
            {
                // Ottieni il Renderer del pezzo
                Renderer renderer = pezzo.GetComponent<Renderer>();

                if (renderer != null)
                {
                    // Se occupato, ripristina il materiale originale
                    if (occupato)
                    {
                        renderer.material = chessPiece.originalMaterial;
                    }

                    // Inverti lo stato di occupato
                    occupato = !occupato;
                }


            }
        }
    }
}
