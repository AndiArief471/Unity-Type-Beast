using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private GameObject cloudsLayer;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = startPoint.transform.position;
        Invoke("AttemptSpawn", spawnInterval);
    }
    void SpawnCloud()
    {
        int randomIndex = Random.Range(0,3);
        GameObject cloud = Instantiate(clouds[randomIndex],cloudsLayer.transform,false);
        
        startPos.y = Random.Range(startPos.y - 30f, startPos.y + 30f);
        cloud.transform.position = startPos;

        float speed = Random.Range(10f, 20f);
        cloud.GetComponent<CloudsScript>().StartFloating(speed, endPoint.transform.position.x);
    }
    void AttemptSpawn()
    {
        SpawnCloud();
        Invoke("AttemptSpawn", spawnInterval);
    }
}