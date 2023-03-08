using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[DisallowMultipleComponent]
[RequireComponent(typeof(CapsuleCollider))]
public class PickUp : MonoBehaviour
{
    static int points = 100;
    [SerializeField] float rotationOffset = 100f;

    bool gotHit = false;
    Transform myTransform;
    Vector3 randomRotation;

    //rotate the pickup
    //add to score when this is shot or crashed into

    //public method to call when shot or collided with

    void Awake()
    {
        myTransform = transform;
    }
    

    private void Start()
    {
        //Random Rotation
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
    }
    private void Update()
    {
        myTransform.Rotate(randomRotation * Time.deltaTime); //"Time.deltaTime" allows to smothen the rotation across different frame rates
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            if(!gotHit)
                PickUpHit();
        }
    }

    public void PickUpHit()
    {
        if(!gotHit)
        {
            gotHit = true;

            Debug.Log("Player Hit Us!!");

            EventManager.ScorePoints(points);
            EventManager.onReSpawnPickUp();
            Destroy(gameObject);
        }




        //call event that we need to add to score (pass in int for score)

        //create an event to spawn a new pickup when this one is picked up

        //destroy itself 

    }
}
