using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Lighter : MonoBehaviour
{

    public GameObject lighter;
    public GameObject flames;

    //public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        //isOn = false;
        flames.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (Input.GetKeyDown("Fire1") && lighter.activeInHierarchy)
    //    //{
    //    //    flames.SetActive(true);
    //    //    isOn = true;
    //    //}

    //    //if (Input.GetButtonDown("Fire2") && lighter.activeInHierarchy && isOn)
    //    //{
    //    //    flames.SetActive(false);
    //    //    isOn = false;
    //    }
    //}

    public void FlameOn()
    {
        flames.SetActive(true);
    }

    public void FlameOff()
    {
        flames.SetActive(false);
    }
}
