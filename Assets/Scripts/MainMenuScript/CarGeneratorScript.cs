using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject CarRight;
    [SerializeField] private float spawnIntervalRight;
    [SerializeField] private GameObject startPointRight;
    [SerializeField] private GameObject endPointRight;
    [SerializeField] private GameObject carLayer;
    Vector3 startPosRight;
   
    // Start is called before the first frame update
    void Start()   
    {
        // Right car
        startPosRight = startPointRight.transform.position;
        Invoke("AttemptSpawnRight", spawnIntervalRight);
       
    }

    void SpawnCarRight()
    {
        // right car
        GameObject carRight = Instantiate(CarRight,carLayer.transform,false);
        carRight.transform.position = startPosRight;
        float speedRight = 45f;
        carRight.GetComponent<CarScript>().StartMoving(speedRight, endPointRight.transform.position.x);
        
    }
    

    void AttemptSpawnRight()
    {
        SpawnCarRight();
        Invoke("AttemptSpawnRight", spawnIntervalRight);
    }
    
}
