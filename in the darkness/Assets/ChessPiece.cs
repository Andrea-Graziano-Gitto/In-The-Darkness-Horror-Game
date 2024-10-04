using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour, IInteractable
{
    public Material originalMaterial;
    private Material highlightedMaterial;
    public Color emissionColor;
    public bool selected;
    public GameObject scac;
    public GameObject casella; // Riferimento alla casella parent

    void Awake()
    {
        // Assegna la casella parent
        casella = transform.parent.gameObject;
        casella.GetComponent<caselleselezione>().locked = true;
    }

    void OnDestroy()
    {
        if (casella != null)
        {
            casella.GetComponent<caselleselezione>().locked = false;
        }
    }

    void Start()
    {
       
        selected = false;
        // Salva il materiale originale del pezzo
        originalMaterial = GetComponent<Renderer>().material;
        // Crea un nuovo materiale clonando quello originale
        highlightedMaterial = new Material(originalMaterial);
        emissionColor = new Color(45 / 255f, 45 / 255f, 45 / 255f); // Converti i valori 61,61,61 in scala 0-1
     
    }

    public void Azione()
    {
        
        
       //if(selected) scac.GetComponent<scacchiera>().occupato = !scac.GetComponent<scacchiera>().occupato;
       // scac.GetComponent<scacchiera>().pezzo = gameObject;
        Debug.Log("cazzo");
       
    }

        void OnMouseEnter()
        {
        // Sostituisci il materiale del pezzo con il materiale clonato e attiva l'emissione

        selected = true;
        if(!scac.GetComponent<scacchiera>().occupato && selected) scac.GetComponent<scacchiera>().pezzo = gameObject;
        if (!scac.GetComponent<scacchiera>().occupato) GetComponent<Renderer>().material = highlightedMaterial;
            highlightedMaterial.EnableKeyword("_EMISSION");
            highlightedMaterial.SetColor("_EmissionColor", emissionColor);
        
        }

    void OnMouseExit()
    {
        // Ripristina il materiale originale quando il mouse esce
        selected = false;
        if (!scac.GetComponent<scacchiera>().occupato) GetComponent<Renderer>().material = originalMaterial;
        if(!scac.GetComponent<scacchiera>().occupato) scac.GetComponent<scacchiera>().pezzo = null;
    }
}
