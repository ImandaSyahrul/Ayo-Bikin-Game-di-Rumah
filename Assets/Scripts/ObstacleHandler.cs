﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    private GameObject _touchedObject;

    [SerializeField]
    private double obstacleDecInc; // Value for each corresponding obstacle that could be sent to game manager

    // Start is called before the first frame update
    void Start()
    {
        // set value of _lifeDecInc in game manager
    }

    // Update is called once per frame
    void Update()
    {
        _touchedObject = InputHandler.GetTouchedObject();
        
        if (_touchedObject != null)
            if (_touchedObject.CompareTag("Obstacle"))
            {
                Debug.Log(_touchedObject.transform.tag);
                Debug.Log("TOUCHED!! " + _touchedObject.transform.name);
                // _touchedObject.SetActive(false);
                //    Set GameManager._obstacleExists to false
            }
    }
}