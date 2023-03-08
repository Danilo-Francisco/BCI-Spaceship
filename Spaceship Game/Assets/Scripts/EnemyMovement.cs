using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float movementSpeed = 10f;

    void Update()
    {
        Turn();
        Move();
    }

    void Turn()
    {
        Vector3 position = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
