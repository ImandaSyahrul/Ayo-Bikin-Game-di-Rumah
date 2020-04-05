using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private GameObject _touchedObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _touchedObject = InputHandler.GetTouchedObject();

        if (_touchedObject != null)
            if (_touchedObject.CompareTag("Player"))
            {
                Debug.Log(_touchedObject.transform.tag);
                Debug.Log("TOUCHED!! " + _touchedObject.transform.name);
                // Menambahkan bar kejenuhan ke game manager
            }
    }
}