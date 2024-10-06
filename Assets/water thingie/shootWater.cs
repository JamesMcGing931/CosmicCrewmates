using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootWater : MonoBehaviour
{
    public Transform waterSpawn;
    public GameObject waterSpawnPrefab;
    public float waterSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SprayWater()
    {
        var water = Instantiate(waterSpawnPrefab, waterSpawn.position, waterSpawn.rotation);
        water.GetComponent<Rigidbody>().velocity = waterSpawn.forward * waterSpeed;
    }
}
