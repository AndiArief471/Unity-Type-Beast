using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCloud : MonoBehaviour
{
    [SerializeField] private GameObject endPoint;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CloudsScript>().StartFloating(20f, endPoint.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
