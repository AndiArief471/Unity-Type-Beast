﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCarScript : MonoBehaviour
{
     private float _speed;
    private float _endPosX;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));

        if(transform.position.x < _endPosX)
        {
            Destroy(gameObject);
        }
    }

    public void StartMoving(float speed, float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }
}
