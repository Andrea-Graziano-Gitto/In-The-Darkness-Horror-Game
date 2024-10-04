using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crackss : MonoBehaviour
{
    public GameObject next;
    public GameObject dist;
    public GameObject distr;
    // Start is called before the first frame update
    public void Awake()
    {
        Invoke("Crs", 2f);
    }
    void Start()
    {
        
    }
    public void Crs()
    {
        next.SetActive(true);
        if (dist != null) Destroy(dist, 0f);
        if (distr != null) Destroy(distr, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
