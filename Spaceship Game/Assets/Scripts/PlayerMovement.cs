using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] Thruster[] thruster;

    Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();
    }

    private void Turn()
    {
        //Turning = turn speed * Time * input 
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float rool = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myTransform.Rotate(-pitch, yaw, -rool);    
    }

    private void Thrust()
    {
        //if we start to thrust call thruster.Activate()
        //when we stop thrusting, call thruster.Activate(false)

        if (Input.GetAxis("Vertical") > 0)
        {
            myTransform.position += myTransform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

            foreach (Thruster t in thruster)
                t.Intensity(Input.GetAxis("Vertical"));
        }

        /*if (Input.GetKeyDown(KeyCode.W))
            foreach (Thruster t in thruster)
                t.Activate();
        else if (Input.GetKeyUp(KeyCode.W))
            foreach (Thruster t in thruster)
                t.Activate(false);*/
        
    }


}
