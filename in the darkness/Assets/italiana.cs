using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class italiana : MonoBehaviour
{
    public GameObject disco;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject c6;
    public GameObject f3;
    public GameObject e4;
    public GameObject e5;

    public bool isCavalloBiancoOnF3 = false;
    public bool isCavalloNeroOnC6 = false;
    public bool isPedoneAlfiereBiancoOnC3 = false;
    public bool isAlfiereBiancoOnC4 = false;
    public bool isAlfiereNeroOnC5 = false;
    public bool isPedoneNeroOnE5 = false;
    public bool isPedoneReOnE4 = false;

    void Start()
    {
        // Inizializzazione se necessaria
    }

    public void discone()
    {
        disco.SetActive(true);
    }

    bool CheckChildName(GameObject obj, string expectedName)
    {
        if (obj.transform.childCount > 0)
        {
            // Ottieni il nome del primo figlio e confronta solo la parte principale
            string childName = obj.transform.GetChild(0).gameObject.name;
            return childName.StartsWith(expectedName);
        }
        else
        {
            Debug.LogWarning(obj.name + " non ha figli.");
            return false;
        }
    }

    void Update()
    {
        if (disco != null)
        {
            if (!disco.activeSelf)
            {
                // Controlla il nome di ciascun child e aggiorna le variabili booleane
                isCavalloBiancoOnF3 = CheckChildName(f3, "cavallobianco");
                isCavalloNeroOnC6 = CheckChildName(c6, "cavallonero");

                isAlfiereBiancoOnC4 = CheckChildName(c4, "alfierebianco");
                isAlfiereNeroOnC5 = CheckChildName(c5, "alfierenero");
                isPedoneNeroOnE5 = CheckChildName(e5, "pedonenero");
                isPedoneReOnE4 = CheckChildName(e4, "pedonere");

                // Invoca discone solo se tutte le condizioni sono true
                if (isCavalloBiancoOnF3 && isCavalloNeroOnC6 &&
                 isAlfiereBiancoOnC4 &&
                    isAlfiereNeroOnC5 && isPedoneNeroOnE5 && isPedoneReOnE4 && !disco.activeSelf)
                {
                    Invoke("discone", 0.001f);
                }
            }
        }
    }
}
