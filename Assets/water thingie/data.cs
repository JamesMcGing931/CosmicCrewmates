using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class data : MonoBehaviour
{
    public TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Plant")
        {
            text.text = "Alfalfa: This crop can survive in the tough volcanic soils of mass, it can also be used as fertiliser to grow food like turnips, radishes and lettuce";
        }
        else if(trigger.gameObject.tag == "Rock1")
        {
            text.text = "Sandstone:\nSedimentary - melting point of 1970°C. Contains: \nKaolinite, Illite, Feldspar, Quartz, Zircon, Tourmaline, Rutile, Granet, Magnetite.";
        }
        else if(trigger.gameObject.tag == "Rock2")
        {
            text.text = "Meteorite:\n'The Heat Shield Rock' was the first ever discovered meteorite found on another planet.\nContains: \nOlivine, Pyroxene, Plogioclase, Troilite, Kamacite, Taenite.";
        }
        else if(trigger.gameObject.tag == "Rock3")
        {
            text.text = "Scoria:\nIgneous - melting point of 2800°C. Contains: \nIron, Magnesium, Feldspar, Pyroxene";
        }
        else if(trigger.gameObject.tag == "Rock4")
        {
            text.text = "Mudstone:\nSedimentary - melting point of 1828°C. Contains:\nKaolinite, Illite, Smectite,Silt, Quartz, Feldspar, Calcite, Dolomite.";
        }
        else
        {
            text.text = "Not a valid sample";
        }
    }

   

    public void OnTriggerExit(Collider other)
    {
        text.text = "Insert Research Object here!\r\n\r\n\r\n<-";
    }
}
