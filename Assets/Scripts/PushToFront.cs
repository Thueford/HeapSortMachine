using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushToFront : MonoBehaviour
{
    // Start is called before the first frame update

    public string layerToPush;

    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = layerToPush;
        Debug.Log(GetComponent<Renderer>().sortingLayerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
