using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Laser[] laser;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Laser l in laser)
            { 
//                Vector3 position = transform.position + (transform.forward * l.Distance);
                l.FireLaser();
            }
        }
    }
}