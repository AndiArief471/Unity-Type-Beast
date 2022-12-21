using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f); // destroying the game object after 2 second
    }

    // Update is called once per frame
    void Update()
    {

    }
}
