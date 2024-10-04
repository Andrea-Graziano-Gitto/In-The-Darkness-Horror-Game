using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setactivefalse : MonoBehaviour
{
    public GameObject closing;
    public GameObject Audioclick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void closied()
    {
        Instantiate(Audioclick, gameObject.transform.position, Quaternion.identity);
        closing.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
