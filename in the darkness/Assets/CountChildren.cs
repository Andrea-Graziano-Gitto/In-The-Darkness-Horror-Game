using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountChildren : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject lid;
    public GameObject bottom;
    public GameObject glass;
    public GameObject cap;
    public GameObject tank;
    public int cachedChildCount;
    public GameObject Eventpost;
    public GameObject Event;

    void Start()
    {
        cachedChildCount = parentObject.transform.childCount;
    }

    void Update()
    {
        int currentChildCount = parentObject.transform.childCount;
        if (currentChildCount != cachedChildCount)
        {
            Debug.Log("Il numero di figli è cambiato: " + currentChildCount);
            cachedChildCount = currentChildCount;
        }
        if (cachedChildCount == 1) Event.SetActive(true);
        if (cachedChildCount == 0)
        {
            Eventpost.SetActive(true);
            tank.SetActive(true);
            Destroy(lid);
            Destroy(cap);
            Destroy(glass);
            Destroy(bottom);
            Destroy(gameObject);
        }
    }
}
