using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{

    private GameObject _jellyParent;

    // Start is called before the first frame update
    void Start()
    {
        _jellyParent = GameObject.Find("JellyParent");
        transform.parent = _jellyParent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

   
}
