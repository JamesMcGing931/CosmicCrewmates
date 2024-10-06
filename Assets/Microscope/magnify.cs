using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnify : MonoBehaviour
{

    public Camera camera;

    public float fov = 40f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.fieldOfView = fov;
        if(fov > 60)
        {
            fov = 60;
        }
        else if(fov < 20)
        {
            fov = 20;
        }
    }

    public void Enlarge()
    {
        fov += 5f;
    }

    public void Unlarge()
    {
        fov -= 5f;
    }
}
