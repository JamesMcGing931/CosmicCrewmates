using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class scanner : MonoBehaviour
{
    private XRSocketInteractor interactor;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void changeGreen()
    {
        light.color = Color.green;
    }

    public void Empty()
    {
        light.color = Color.red;
    }
}
