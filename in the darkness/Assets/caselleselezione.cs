using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caselleselezione : MonoBehaviour, IInteractable
{
    private Material originalMaterial;
    private Material highlightedMaterial;
    public Color emissionColor;
    public bool selected;
    public bool locked;
    public GameObject scac;
    public bool attivo;
    public GameObject Audioset;

    void Start()
    {
        selected = false;
        attivo = false;
        // Salva il materiale originale del pezzo
        originalMaterial = GetComponent<Renderer>().material;
        // Crea un nuovo materiale clonando quello originale
        highlightedMaterial = new Material(originalMaterial);
        emissionColor = new Color(45 / 255f, 45 / 255f, 45 / 255f); // Converti i valori 61,61,61 in scala 0-1
    }

    public void Azione()
    {

        if (scac.GetComponent<scacchiera>().pezzo != null && attivo && !locked)
        {
            ChessPiece chessPiece = scac.GetComponent<scacchiera>().pezzo.GetComponent<ChessPiece>();
            Quaternion rotazione = scac.GetComponent<scacchiera>().pezzo.transform.rotation;
            if (chessPiece != null)
            {
                // Ottieni il Renderer del pezzo
                Renderer renderer = scac.GetComponent<scacchiera>().pezzo.GetComponent<Renderer>();

                if (renderer != null)
                {
                    // Se occupato, ripristina il materiale originale

                    renderer.material = chessPiece.originalMaterial;


                }
            }
                GameObject instance = Instantiate(scac.GetComponent<scacchiera>().pezzo, gameObject.transform.position, rotazione, gameObject.transform);
            if (Audioset != null) Instantiate(Audioset, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            Destroy(scac.GetComponent<scacchiera>().pezzo);
         
            GetComponent<Renderer>().material = originalMaterial;
            //instance.transform.position = new Vector3(0f, 0f, 0f);
            scac.GetComponent<scacchiera>().occupato = false;
            scac.GetComponent<scacchiera>().pezzo = null;
            Debug.Log("Azione executed");
        }
      
    }


    void OnMouseEnter()
    {
        // Highlight the piece if it's not selected and not occupied

        attivo = true;
        if (!locked)
        {
            GetComponent<Renderer>().material = highlightedMaterial;
            highlightedMaterial.EnableKeyword("_EMISSION");
            highlightedMaterial.SetColor("_EmissionColor", emissionColor);
        }
            
        
       
    }

    void OnMouseExit()
    {
        // Restore the original material if not selected
        attivo = false;
     if(!locked) GetComponent<Renderer>().material = originalMaterial;
        
    }
}
