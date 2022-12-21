using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftCarGeneratorScript : MonoBehaviour
{
     [SerializeField] private GameObject CarLeft;
     [SerializeField] private float spawnIntervalLeft;
     [SerializeField] private GameObject startPointLeft;
     [SerializeField] private GameObject endPointLeft;
     [SerializeField] private GameObject carLayer;
     Vector3 startPosLeft;

      void Start()   
    {
        // Left Car
        startPosLeft = startPointLeft.transform.position;
        Invoke("AttemptSpawnLeft", spawnIntervalLeft);
    }

   
    void SpawnCarLeft()
    {
        // left car
        GameObject carLeft = Instantiate(CarLeft,carLayer.transform,false);
        carLeft.transform.position = startPosLeft;
        float speedLeft = -60f;
        carLeft.GetComponent<LeftCarScript>().StartMoving(speedLeft, endPointLeft.transform.position.x);
    }

   
    void AttemptSpawnLeft()
    {
        SpawnCarLeft();
        Invoke("AttemptSpawnLeft", spawnIntervalLeft);
    }
}
