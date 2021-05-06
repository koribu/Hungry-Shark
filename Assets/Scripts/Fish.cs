using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _fishParent;
    void Start()
    {
        _fishParent = GameObject.Find("ColorFishParent");
        transform.parent = _fishParent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
