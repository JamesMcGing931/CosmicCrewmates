using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // transform.localScale = new Vector3(.1f, .1f, .1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * 0.5f;
    }
}
